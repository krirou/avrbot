
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tom;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing;

namespace AVrBoT_v4
{
    public class RichEditorCsharp : RichTextBox
    {
        private Thread th = null;

        public RichEditorCsharp()
        {
            // Création du menu
         
            miCopy = new ToolStripMenuItem("Copier", null, OnMenuItemClick, Keys.Control | Keys.C);
            miCut = new ToolStripMenuItem("Couper", null, OnMenuItemClick, Keys.Control | Keys.X);
            miPaste = new ToolStripMenuItem("Coller", null, OnMenuItemClick, Keys.Control | Keys.V);
            mMenu = new ContextMenuStrip();
            mMenu.Items.AddRange(new ToolStripMenuItem[] { miCopy, miCut, miPaste });
            mMenu.Opening += OnMenuOpening;
            this.ContextMenuStrip = mMenu;
            //event
           // this.KeyDown += richTextBox1_KeyDown;
            //this.ScrollBars=ForcedBoth;
        }
       
        #region WIN32

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int message, IntPtr wParam, out IntPtr lParam);

        private const int EM_GETOLEINTERFACE = WM_USER + 60;
        public const int WM_USER = 0x0400;

        #endregion
        /// <summary>
        /// Menu "clic-droit"
        /// </summary>
        private ContextMenuStrip mMenu;
        /// <summary>
        /// Eléments du menu
        /// </summary>
        private ToolStripMenuItem miCopy, miCut, miPaste;
        #region menu
        /// <summary>
        /// Gestion des éléments de menu
        /// </summary>
        /// <param name="sender">objet ayant généré l'évènement</param>
        /// <param name="e">paramètres de l'évènement</param>
        private void OnMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem miSender = (ToolStripMenuItem)sender;

            // Copier / Couper
            if (miSender == miCopy || miSender == miCut)
            {
                // On passe au presse-papier le texte sélectionné
                Clipboard.SetText(this.SelectedText);

                if (miSender == miCut)
                {
                    //en cas de "Couper", on enlève le texte sélectionné
                    int i = this.SelectionStart;
                    this.Text = this.Text.Substring(0, this.SelectionStart) + this.Text.Substring(this.SelectionStart + this.SelectionLength);
                    this.SelectionStart = i;
                }
            }

            // Coller
            if (miSender == miPaste)
            {
                // Ajout du texte contenu dans le presse-papier
                string txt = Clipboard.GetText();
                if (this.SelectionLength != 0)
                {
                    int i = this.SelectionStart;
                    this.Text = this.Text.Substring(0, this.SelectionStart) + this.Text.Substring(this.SelectionStart + this.SelectionLength);
                    this.SelectionStart = i;
                }

                // On vérifie (et refait si nécessaire) l'indentation
                int k = this.SelectionStart;
                this.Text = this.Text.Substring(0, k) + txt + this.Text.Substring(k);

                int indent = 0;
                string[] text = this.Text.Split('\n');
                for (int i = 0; i < text.Length; i++)
                {
                    int tmp = new Regex("\t").Matches(text[i]).Count;
                    if (indent != tmp)
                    {
                        string line = text[i].Trim();
                        for (int j = 0; j < indent; j++)
                            line = "\t" + line;
                        text[i] = line;
                    }

                    if (text[i].Contains("{") && !text[i].Contains("}"))
                        tmp++;
                    if (text[i].Contains("}") && !text[i].Contains("{"))
                        tmp = Math.Max(0, tmp - 1);
                    indent = tmp;
                }
                this.Text = "";
                for (int i = 0; i < text.Length; i++)
                    this.Text += text[i] + (i == text.Length - 1 ? "" : "\n");

                this.SelectionStart = k + txt.Length;
            }
        }

        /// <summary>
        /// Gestion de l'ouverture du menu
        /// </summary>
        /// <param name="sender">objet ayant généré l'évènement</param>
        /// <param name="e">paramètres de l'évènement</param>
        private void OnMenuOpening(object sender, CancelEventArgs e)
        {
            miCopy.Enabled = true;
            miCut.Enabled = true;
            miPaste.Enabled = true;

            if (this.SelectionLength == 0)
            {
                // Si rien n'est sélectionner, on ne peut pas copier!!
                miCopy.Enabled = false;
                miCut.Enabled = false;
            }
            if (!Clipboard.ContainsText())
            {
                // Le presse-papier est vide, impossible de coller!!
                miPaste.Enabled = false;
            }
        }
        #endregion
        #region autoindent
        /// <summary>
        /// Sur appuie d'une touche, on vérifie et on crée (si besoin) l'indentation
        /// </summary>
        /// <param name="sender">l'objet ayant généré l'évènement</param>
        /// <param name="e">paramètres de l'évènement</param>
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                // Enter
                case '\r':
                    // On compte le nombre de 'tab' de la ligne précédente
                    string temp = Convert.ToString(this.Lines.GetValue(this.GetLineFromCharIndex(this.SelectionStart - 1)));
                    Regex tab = new Regex("\t");

                    int indent = tab.Matches(temp).Count;
                    if (temp.EndsWith("{"))
                        // si la ligne finit par "{" (début de struct / class / etc...) on ajoute une indentation
                        indent++;

                    temp = Convert.ToString(this.Lines.GetValue(this.GetLineFromCharIndex(this.SelectionStart)));
                    if (temp.Contains("}") && !temp.Contains("{"))
                        // si la ligne contient "}" (fin de struct / class / etc...) on enlève une indentation
                        indent = Math.Max(0, indent - 1);

                    // et on la place dans le texte
                    string temp2 = "{TAB " + indent + "}";

                    SendKeys.Send(temp2);
                    break;

                // '}'
                case 187:
                    // si on a appuyé sur "}", c'est qu'on finit un groupe et on enlève une indentation
                    this.Focus();
                    SendKeys.Send("^(%()){LEFT}{BKSP}{RIGHT}");
                    break;

                default:
                    break;
            }
        }
        #endregion


        #region TOM OBJECT MODEL

        private ITextDocument _myITextDocument = null;
        private ITextDocument myITextDocument
        {
            get
            {
                if (_myITextDocument == null)
                    _myITextDocument = Create();

                return _myITextDocument;
            }
            set
            {
                if (_myITextDocument != null)
                    Marshal.ReleaseComObject(_myITextDocument);

                _myITextDocument = value;
            }
        }

        private ITextDocument Create()
        {
            IntPtr theRichEditOle = IntPtr.Zero;
            if (SendMessage(Handle, EM_GETOLEINTERFACE, IntPtr.Zero, out theRichEditOle) == 0)
            {
                throw new System.ComponentModel.Win32Exception();
            }

            try
            {
                ITextDocument theTextDoc = (ITextDocument)Marshal.GetTypedObjectForIUnknown(theRichEditOle, typeof(ITextDocument));
                return theTextDoc;
            }
            finally
            {
                Marshal.Release(theRichEditOle);
            }
        }

        private void FreezeDocument(ITextDocument doc)
        {
            doc.Freeze();
        }

        private void UnFreezeDocument(ITextDocument doc)
        {
            doc.Unfreeze();
        }

        private Boolean setForeColor(int start, int len, System.Drawing.Color backcolor)
        {
            Boolean ret = false;

            ITextRange range = myITextDocument.Range(start, start + len);

            FreezeDocument(myITextDocument);

            range.Font.ForeColor = System.Drawing.ColorTranslator.ToOle(backcolor);

            UnFreezeDocument(myITextDocument);

            return ret;
        }

        #endregion

        #region DELEGATE

        private delegate Boolean Updatecolor(int start, int len, System.Drawing.Color backcolor);

        #endregion

        #region KEYWORD C#

        private String[] Word = new String[] { 
            "abstract","as","base","bool","break","byte","case","catch","char","checked","class","const","continue","decimal",
            "default","delegate","do","double","else","enum","event","exdouble","exfloat","explicit","extern","false","finally","fixed",
            "float","for","foreach","get","goto","if","implicit","in","int","interface","internal","is","lock","long","namespace",
            "new","null","object","operator","out","override","private","protected","public","readonly","ref","return","sbyte","sealed",
            "set","short","sizeof","static","string","struct","switch","this","throw","true","try","typeof","uint","ulong","unchecked",
            "unsafe","ushort","using","virtual","void","while","unsigned","short","else","elseif","end","break","uint16_t",
            "servo","usart_avrbot","afficheur_avrbot","moteur_pap","avrbot"
        };
        private String[] langavrbot = new String[] {
            "config_port_sortie","config_port_entree","port_sortie","moteur_pap_vitesse","moteur_pap_position","moteur_pap_sens",
            "servo_angle","_delay_ms","_delay_us","sleep","include","define","PORTA","PORTB","PORTC","PORTD","PORTE","PORTF",
            "DDRA","DDRB","DDRC","DDRD","DDRE","DDRF","PA","PB","PC","PD","PE","PF","RXN","TXN","step_for_pap","step_bac_pap",
            "rotat_step_pap","T_Vitesse_pap","config_interface_pap","config_timer_pap","sei","cli","sens","config_adc_pap","start_adc",
            "nmb","cod","USARTInit","USARTReadChar","USARTWriteChar","USART_newline","USARTWrite_S_Char","read_nomber","bit_is_clear",
            "bit_is_set","ISR","ADC","config_timer_servo","config_interface_servo"
        };
        private String[] artificiel_intelligence = new String[] {"include"+"<"+"moteur_pap.h"+">","include"+"<"+"servo.h"+">" };

        /// <summary>
        /// gerene un motif de regex
        /// </summary>
        /// <returns></returns>
        private string CompileKeywordsintelligence()
        {
            string mKeywords = "";

            for (int i = 0; i < artificiel_intelligence.Length; i++)
            {
                string strKeyword = artificiel_intelligence[i];

                if (i == artificiel_intelligence.Length - 1)
                    mKeywords += "\\b" + artificiel_intelligence[i] + "\\b";
                else
                    mKeywords += "\\b" + artificiel_intelligence[i] + "\\b|";
            }
            return mKeywords;
        }
        private string CompileKeywords()
        {
            string mKeywords = "";

            for (int i = 0; i < Word.Length; i++)
            {
                string strKeyword = Word[i];

                if (i == Word.Length - 1)
                    mKeywords += "\\b" + Word[i] + "\\b";
                else
                    mKeywords += "\\b" + Word[i] + "\\b|";
            }
            return mKeywords;
        }
        private string CompileKeywordsavrbot()
        {
            string mKeywords = "";

            for (int i = 0; i < langavrbot.Length; i++)
            {
                string strKeyword = langavrbot[i];

                if (i == langavrbot.Length - 1)
                    mKeywords += "\\b" + langavrbot[i] + "\\b";
                else
                    mKeywords += "\\b" + langavrbot[i] + "\\b|";
            }
            return mKeywords;
        }
        #endregion
       

        /// <summary>
        /// Mise a jour inter-Thread
        /// </summary>
        /// <param name="start">debut de mot</param>
        /// <param name="len">fin de mot</param>
        /// <param name="color">couleur désiré</param>
        private void UpdateContent(int start, int len, Color color)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Updatecolor(setForeColor), new Object[] { start, len, color });
            }
            else
                setForeColor(start, len, color);
        }

        /// <summary>
        /// Color le text
        /// </summary>
        /// <param name="data">Text de la richtextbox</param>
        public void ColorSystaxe(object data)
        {
            String Text = data as String;
            Match regMatch;

            UpdateContent(0, Text.Length, Color.Black);

            /* color mot clé */
            Regex reg = new Regex(CompileKeywords(), RegexOptions.Singleline | RegexOptions.Compiled);
            for (regMatch = reg.Match(Text); regMatch.Success; regMatch = regMatch.NextMatch())
            {
                int nStart = regMatch.Index;
                int nLenght = regMatch.Length;
                UpdateContent(nStart, nLenght, Color.Blue);
                
            }
            //ajouter des fonction util pour la simplicité de programmation **artificiel intelligence****
            Regex reg3 = new Regex(CompileKeywordsintelligence(), RegexOptions.Singleline | RegexOptions.Compiled);
            for (regMatch = reg3.Match(Text); regMatch.Success; regMatch = regMatch.NextMatch())
            {
                /*int nStart = regMatch.Index;
                int nLenght = regMatch.Length;
                ITextRange range = myITextDocument.Range(nStart, nStart + nLenght);

                FreezeDocument(myITextDocument);*/
   this.AppendText("ISR(TIMER0_COMP_vect)"+"//interruption du timer pour moteur pap"+"\n"+
    "{"+"\n"+
	 "if"+"("+"step"+")"+"\n"+
	    "{"+"\n"+
	     "rotat_step();"+"\n"+
    	 "step--;"+"\n"+
	    "}"+"\n"+	 
	 "TCNT0=0;"+"\n"+
	 
	"}"
);
            }
            //fonction avrbot
            Regex reg2 = new Regex(CompileKeywordsavrbot(), RegexOptions.Singleline | RegexOptions.Compiled);
            for (regMatch = reg2.Match(Text); regMatch.Success; regMatch = regMatch.NextMatch())
            {
                int nStart = regMatch.Index;
                int nLenght = regMatch.Length;
                UpdateContent(nStart, nLenght, Color.DarkOrchid);
            }

            /* color string avec ou sans @*/
            reg = new Regex("(@\"|\")[^\"]*(?:\\\\.[^\"]*)*\"", RegexOptions.Multiline | RegexOptions.Compiled);
            for (regMatch = reg.Match(Text); regMatch.Success; regMatch = regMatch.NextMatch())
            {
                int nStart = regMatch.Index;
                int nLenght = regMatch.Length;
                UpdateContent(nStart, nLenght, Color.Red);
            }

            /* color commentaire // */
            reg = new Regex("[^:]//[^\r\n]*", RegexOptions.Singleline | RegexOptions.Compiled);
            for (regMatch = reg.Match(Text); regMatch.Success; regMatch = regMatch.NextMatch())
            {

                int nStart = regMatch.Index;
                int nLenght = regMatch.Length;
                UpdateContent(nStart, nLenght, Color.Green);
            }
            //coleur entier 1
            reg = new Regex(@"\s\d+(;|,|}|\s)", RegexOptions.Singleline | RegexOptions.Compiled);
            for (regMatch = reg.Match(Text); regMatch.Success; regMatch = regMatch.NextMatch())
            {

                int nStart = regMatch.Index;
                int nLenght = regMatch.Length;
                UpdateContent(nStart, nLenght, Color.Orange);
            }
            //coleur entier 123
            reg = new Regex(@"[[]\d+", RegexOptions.Singleline | RegexOptions.Compiled);
            for (regMatch = reg.Match(Text); regMatch.Success; regMatch = regMatch.NextMatch())
            {

                int nStart = regMatch.Index;
                int nLenght = regMatch.Length;
                UpdateContent(nStart, nLenght, Color.Orange);
            }
            /* color commentaire multiligne */
            reg = new Regex("/\\*([^*]|(\\*+([^*/])))*\\*+/", RegexOptions.Multiline | RegexOptions.Compiled);
            for (regMatch = reg.Match(Text); regMatch.Success; regMatch = regMatch.NextMatch())
            {
                int nStart = regMatch.Index;
                int nLenght = regMatch.Length;
                UpdateContent(nStart, nLenght, Color.Green);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            ColorSystaxe(Text);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            

             
 //arrete le traitement si l'analise est dejas en cours 
             


           if (th != null && th.IsAlive)
                return;

            

             
// lance l'analyse dans un thread
             


            th = new Thread(new ParameterizedThreadStart(ColorSystaxe));
            th.IsBackground = true;
            th.Start(Text);
        }
    }
}


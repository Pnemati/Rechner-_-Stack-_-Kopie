using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rechner___Stack____Kopie
{
    public partial class Form1 : Form
    {
        string x;
        double xx;
        double y;
        double val1;
        double val2;
        string op;
        Stack<double> NumberStack;
        Stack<string> OperStack;
        EvaluateClass EvaluateC;
        public Form1()
        {
            InitializeComponent();
            NumberStack = new Stack<double>();
            OperStack = new Stack<string>();
            EvaluateC = new EvaluateClass();
        }

        private void NumbersClick(object sender, EventArgs e)
        {
            Button w = (Button)sender;
            x = w.Text;
            xx = Convert.ToDouble(x);
            NumberStack.Push(xx);
            if(OperStack.Count() != 0 && OperStack.Peek() == "^")
            {
                val2 = NumberStack.Pop();
                val1 = NumberStack.Pop();
                op = OperStack.Pop();
                EvaluateC.Eval(val1, val2, op, ref y);
                NumberStack.Push(y);
            }
            if(OperStack.Count() != 0 && OperStack.Peek() == "*")
            {
                val2 = NumberStack.Pop();
                val1 = NumberStack.Pop();
                op = OperStack.Pop();
                EvaluateC.Eval(val1, val2, op, ref y);
                NumberStack.Push(y);
            }
            if (OperStack.Count() != 0 && OperStack.Peek() == "/")
            {
                val2 = NumberStack.Pop();
                val1 = NumberStack.Pop();
                op = OperStack.Pop();
                EvaluateC.Eval(val1, val2, op, ref y);
                NumberStack.Push(y);
            }
            DisplayTB.Text += x;
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            Button w = (Button)sender;
            op = w.Text;
            switch (op)
            {
                case "+":   { op = "+"; OperStack.Push(op); break; }
                case "-":   { op = "-"; OperStack.Push(op); break; }
                case "×":   { op = "*"; OperStack.Push(op); break; }
                case "÷":   { op = "/"; OperStack.Push(op); break; }
                case "(":   { op = "("; OperStack.Push(op); break; }
                case "x^y": { op = "^"; OperStack.Push(op); break; }
            }
            DisplayTB.Text += op;
            if (op == ")")
            {
                while (OperStack.Peek() != "(")
                {
                    val2 = NumberStack.Pop();
                    op  = OperStack.Pop();
                    val1 = NumberStack.Pop();
                    EvaluateC.Eval(val1, val2, op, ref y);
                }
                OperStack.Pop();
                NumberStack.Push(y);
            }

            //DisplayTB.Text += op;
        }

        private void EvaluateB_Click(object sender, EventArgs e)
        {
            DisplayTB.Text += " = ";
            while(OperStack.Count() != 0)
            {
                op = OperStack.Pop();
                val2 = NumberStack.Pop();
                val1 = NumberStack.Pop();
                if (op != "*" || op != "/")
                {
                    EvaluateC.Eval(val1, val2, op, ref y);
                    NumberStack.Push(y);
                }
            }
            DisplayTB.Text += y;
        }
    }
}

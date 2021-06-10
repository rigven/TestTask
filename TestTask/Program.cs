using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;


namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            AutomationElement mainWindowAE = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "MainWindow"));
            AutomationElement buttonControl = mainWindowAE.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Log In"));
            InvokePattern ivkp = buttonControl.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ivkp.Invoke();

            AutomationElement authTestAE = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Подключение к myserver"));
            AutomationElement textFieldControl = authTestAE.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "1003"));
            ValuePattern vp = textFieldControl.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            vp.SetValue("testuser");
            textFieldControl = authTestAE.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "1005"));
            vp = textFieldControl.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            vp.SetValue("testpassword");

            buttonControl = authTestAE.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "1"));
            ivkp = buttonControl.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ivkp.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgMethodsAndParameters101

{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        //events work different from a standard method for passing vars - same for okButton.
        {
        }

        protected void okButton_Click(object sender, EventArgs e)
        {

//  ============  These are all from within this class (Default)  ============  

            int test = runTest(); resultLabel.Text = string.Format("runTest() = : {0}<br/>", test);
            //returns:  runTest() = : 17

            runTest2();
            // returns-OUTPUT FROM THE METHOD:  runTest2(): 16


            runTest3(); resultLabel.Text += string.Format("runTest3(): {0}<br/>", test3);
            // returns: runTest3(): 15


            test = runTest4(test3); resultLabel.Text += string.Format("runTest4(): {0} +var test3: {1}<br/>", test, test3);
            // returns:  runTest4(): 20 +var test3: 15
            


//  ============  These are all from OUTSIDE this class (ClassTest)  ============ 
             
            ClassTest classTest = new ClassTest(); //classTest is just a handle to the class

            int newTest = classTest.runClassTest(); resultLabel.Text += string.Format("classTest1: {0}<br/>", newTest);
            // returns:  classTest1: 40

            int catAge = 7; resultLabel.Text += string.Format("Senge age test: {0}<br/>", classTest.xtraCredit(catAge));
            // returns:  Senge age test: 56

            resultLabel.Text += string.Format("v.2.Senge age test: {0}<br/>", classTest.xtraCredit(8));
            // returns:  v.2.Senge age test: 64

            int creditDefault = 5;
            creditDefault = ClassTest.xtraCreditOutsideClass(creditDefault);
            resultLabel.Text += string.Format("Outside class Static: {0}<br/>", creditDefault);
            // returns:  Outside class Static: 105


//  ============  These are STATIC - inside and outside class  ============ 

            creditDefault = 14;
            creditDefault = SameClassCredit(creditDefault);
            resultLabel.Text += string.Format("Same class Static: {0}<br/>", creditDefault);
            // returns:  Same class Static: 1014

            int voidPrep = classTest.PreVoidMethod();
            classTest.VoidMethod2(voidPrep);
            resultLabel.Text += string.Format("Outside class Static VOID: {0} or? {1}<br/>", voidPrep, classTest.MyProp);
            // returns:  Outside class Static VOID: 800 or? 808

        }


//  ============  INSIDE class (default) methods  ============ 

        public int runTest()        // resultLabel unreachable code
        {   int ab = 7;     int cd = 10;    int testA = ab + cd;
            return testA;       }

        
        private void runTest2()
        {   int ef = 6;     int gh = 10;    int test2 = ef + gh;
            resultLabel.Text += string.Format("runTest2(): {0}<br/>", test2);       }


        int test3;
        private void runTest3()
        {   int ij = 5;     int kl = 10;    test3 = ij + kl;
            runTest4(test3);    } //resultLabel info passed with exterior var, but is also reachable here


        public int runTest4(int test3)  // resultLabel unreachable code
        {   int testSomething4 = test3 + 5;
            return testSomething4;      }


        public static int SameClassCredit(int creditSameClass)
        { creditSameClass += 1000; return creditSameClass; }


    }       //  ===========  end Default class  ===========  



    public class ClassTest
    {
        public int MyProp { get; set; }  // this is a property - and way to get values out


//  ============  OUTSIDE class (default) methods ; inside class ClassTest  ============ 


        public int runClassTest() // to get classVarA out - it needs to return a value (=no void)
        {   int x = 5;  int y = 8;  int z = x * y;
            int classVarA = z; return classVarA;        }


        public int xtraCredit(int SengeAge)
        { SengeAge += SengeAge * 7; return SengeAge; }


        public static int xtraCreditOutsideClass(int credit) // TO GET VALUE, can't be VOID
        { credit += 100; return credit; }


        public int PreVoidMethod()
        { int voidCredit = 800; return voidCredit; }


        public void VoidMethod2(int voidCredit)
        {   voidCredit += 8;
            this.MyProp += voidCredit;      } // using a prop to get a value out



    }
}

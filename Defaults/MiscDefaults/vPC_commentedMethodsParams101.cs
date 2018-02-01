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
            // PUBLIC INT runTest(): returns testA =IRRELEVANT ... just a formula of what to do with [ int test ]
            // method with a type (return value, int in this case) - CANNOT access resultLabel



            runTest2();
            // printing is output from the method (void):  runTest2(): 16
            // PRIVATE VOID runTest2(): when called prints out the value FROM WITHIN the method



            runTest3();
            resultLabel.Text += string.Format("runTest3(): {0}<br/>", test3);
            // returns: runTest3(): 15
            // PRIVATE VOID runTest3(): used a DEFAULT CLASS VAR inside the method so it could be printed here
            // var with class-wide designation
            // could have been printed inside the method
            // ** called public int runTest4 and passed its var value = [ runTest4(test3) ]



            // int test declared above
            test = runTest4(test3);
            resultLabel.Text += string.Format("runTest4(): {0} +var test3: {1}<br/>", test, test3);
            // returns:  runTest4(): 20 +var test3: 15
            // ** PUBLIC INT runTest4(int test3): returns testsomething4 =IRRELEVANT= formula of what to do with [ test3 ]
            // ALLOWS ACCESS to a PRIVATE VOID var!!



//  ============  These are all from OUTSIDE this class (ClassTest)  ============ 


            //classTest is just a handle to the class
            ClassTest classTest = new ClassTest(); //classTest is just a handle to the class


            // to be accessible - class ClassTest methods MUST be public



            // local var declared:
            int newTest = classTest.runClassTest();
            resultLabel.Text += string.Format("classTest1: {0}<br/>", newTest);
            // returns:  classTest1: 40
            // PUBLIC INT runClassTest(): return names in method IRRELEVANT = just a formula



            // local var declared:
            int catAge = 7;
            resultLabel.Text += string.Format("Senge age test: {0}<br/>", classTest.xtraCredit(catAge));
            // returns:  Senge age test: 56
            // PUBLIC INT xtraCredit(int SengeAge):  SengeAge=IRRELEVANT, example for formula
            // local var catAge replaces method var SengeAge TO GET THIS TO WORK




            resultLabel.Text += string.Format("v.2.Senge age test: {0}<br/>", classTest.xtraCredit(8));
            // returns:  v.2.Senge age test: 64
            // SAME PUBLIC INT xtraCredit(int SengeAge): as above - but actual int entered instead of local var





//  ============  These are STATIC methods - inside and outside class  ============ 


            // *OUTSIDE* class method used:
            // local var declared:
            int creditDefault = 5;

            // needed extra step to access - NOTICE CLASS NAME -NOT- handle name (classTest)
            creditDefault = ClassTest.xtraCreditOutsideClass(creditDefault);

            resultLabel.Text += string.Format("Outside class Static: {0}<br/>", creditDefault);
            // returns:  Outside class Static: 105
            // PUBLIC STATIC INT xtraCreditOutsideClass(int credit):  int credit is IRRELEVANT; just formula




            // *INSIDE* class method used:
            // local var creditDefault declared above
            creditDefault = 14;

            creditDefault = SameClassCredit(creditDefault);
            // PUBLIC STATIC INT SameClassCredit(int creditSameClass) ... adds 1000 to creditDefault

            resultLabel.Text += string.Format("Same class Static: {0}<br/>", creditDefault);
            // returns:  Same class Static: 1014
            // PUBLIC STATIC INT SameClassCredit(int creditSameClass):  int creditSameClass = IRRELEVANT, =formula





            // *OUTSIDE* class method used:
// ========== // NOT STATIC ... This is a PUBLIC VOID/ PUBLIC INT ***COMBO*** 
            // -- !! uses class property to get value out
 
                      
            // local var declared
            int voidPrep = classTest.PreVoidMethod();
            // PUBLIC INT PreVoidMethod(): assigns & returns a var of 800

            classTest.VoidMethod2(voidPrep);
            // PUBLIC VOID VoidMethod2(int voidCredit): second method adds 8 to 800 from first method
            // the trick is how to access the new value ...

            resultLabel.Text += string.Format("Outside class Static VOID: {0} or? {1}<br/>", 
                voidPrep, classTest.MyProp);
/*            // returns:  Outside class Static VOID: 800 or? 808
            // PUBLIC VOID VoidMethod(int voidCredit):  int voidCredit=IRRELEVANT - just a formula
            // local var voidPrep stays at 800 ... to get VOID result out
            // use a class property from the same class:
            
            public void VoidMethod2(int voidCredit)
            {   voidCredit += 8;
                this.MyProp += voidCredit;      } // using a prop to get a value out    
*/           


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


        // to be accessible - class ClassTest methods MUST be public
        // exception is if public method uses private ClassTest method to get a result (~as a tool)
        // the result or formula cannot be accessed directly by another class


        public int runClassTest() // to get value out - it needs to return a value (=no void)
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
 
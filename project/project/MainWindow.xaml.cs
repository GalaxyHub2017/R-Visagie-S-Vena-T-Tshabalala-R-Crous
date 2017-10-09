using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.Windows.Threading;
using System.IO;

using System.Diagnostics;
namespace project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class GirlAlreadyHereException : ApplicationException
    {

    }
    public class Question
    {
        public string Quest { get; private set; }
        public string CorrectResponse { get; private set; }
        public string Incorrect1 { get; private set; }
        public string Incorrect2 { get; private set; }
        public string HerResponse1 { get; private set; }
        public string HerResponse2 { get; private set; }
        public string HerResponse3 { get; private set; }

        public Question(string q, string r, string w1, string w2, string hr1, string hr2, string hr3 )
        {
            Quest=q;
            CorrectResponse =r;
            Incorrect1 =w1;
            Incorrect2 = w2;
            HerResponse1 = hr1;
            HerResponse2 = hr2;
            HerResponse3 = hr3;
        }
        public override string ToString()
        {
            Button a = new Button();
            Button b = new Button();
            Button c = new Button();
            Canvas.SetTop(a, 100);
            Canvas.SetTop(b, 300);
            Canvas.SetTop(c, 500);
            Canvas.SetLeft(a, 100);
            Canvas.SetLeft(b, 300);
            Canvas.SetLeft(c, 500);
            a.Content = $"{Incorrect1}";
            b.Content = $"{CorrectResponse}";
            c.Content = $"{Incorrect2}";
            return $"{Quest}";
           
        }
    }
    public class Questtraits
    {
        public string Correctquest { get; private set; }
        public string IncorrectQuest1 { get; private set; }
        public string IncorrectQuest2 { get; private set; }
        public string herResponseCorrect { get; private set; }
        public string herResponseIncorrect { get; private set; }
        public Questtraits(string cq, string iq1, string iq2, string hrc, string hri)
        {
            Correctquest = cq;
            IncorrectQuest1 = iq1;
            IncorrectQuest2 = iq2;
            herResponseCorrect = hrc;
            herResponseIncorrect = hri;
        }

       
    }
    public class Girl
    {
        public int Progress { get; set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public double Height { get; private set; }
        public double Weight { get; private set; }
        public string Occupation { get; private set; }
        public string FavHangOut { get; private set; }
        public string BreastSize { get; private set; }
        public string Education { get; private set; }
        public string FavouriteBook { get; private set; }
        public string EyeColour { get; private set; }
        public List<Question> Q1 { get; private set; }
        public Girl(string n, int a, double h, double w, string o, string f, string b, string ed, string fb, string ec)
        {
            Q1 = new List<Question>();
            Name=n;
            Age= a;
            Height = h;
            Weight = w;
            Occupation = o;
            FavHangOut = f;
            BreastSize = b;
            Education = ed;
            FavouriteBook = fb;
            EyeColour = ec;
            Progress = 0;
        }
        public override string ToString()
        {
           
            return $"{Name}";
        }
    }
    

    public partial class MainWindow : Window
    {
        public void Load()
        {
            string[] zero = File.ReadAllLines("..\\..\\girl0-Progress.txt");
            string[] one = File.ReadAllLines("..\\..\\girl1-Progress.txt");
            string[] two = File.ReadAllLines("..\\..\\girl2-Progress.txt");
            Joanne.Progress = Convert.ToInt32(zero[0]);
            Tiffany.Progress = Convert.ToInt32(zero[0]);
            Jackie.Progress = Convert.ToInt32(zero[0]);
        }
        public void displayStartupScreen()
        {
            Canvas candies = new Canvas();
            candies.VerticalAlignment = VerticalAlignment.Stretch;
            candies.HorizontalAlignment = HorizontalAlignment.Stretch;
            candies.Background = Brushes.DeepPink;
            Button a = new Button();
            Button b = new Button();
            a.Height = 100;
            a.Width = 300;
            b.Height = 100;
            b.Width = 300;
            candies.Children.Add(a);
            candies.Children.Add(b);
            a.Content = "New Game";
            b.Content = "Load Game";
            Canvas.SetTop(a, (candies.ActualHeight / 2) - a.ActualHeight - 2.5);
            Canvas.SetTop(b, (candies.ActualHeight / 2) - b.ActualHeight + 2.5);
            Canvas.SetLeft(a, (candies.ActualWidth / 2) - a.ActualWidth );
            Canvas.SetLeft(b, (candies.ActualWidth / 2) - b.ActualWidth );

        }
       
        
        public void Save()
        {
            TextWriter myfile = File.CreateText("..\\..\\girl0-Progress.txt");
            TextWriter myfile1 = File.CreateText("..\\..\\girl1-Progress.txt");
            TextWriter myfile2 = File.CreateText("..\\..\\girl2-Progress.txt");
            myfile.WriteLine($"{Joanne.Progress}");
            myfile1.WriteLine($"{Tiffany.Progress}");
            myfile2.WriteLine($"{Jackie.Progress}");

        }
        Girl Joanne;
        Girl Tiffany;
        Girl Jackie;
        Girl current;
        DispatcherTimer timer;
        string selected = "batman";
        Random qng = new Random();
        int ques;
        int girlNum;
        Random prod = new Random();
        int salsa;

        //Relative path of all our images
        string inThisProject = "pack://application:,,,/";

        //Bitmap Array for our girls 
        public BitmapImage[] theGirls;

        //Array for the backgrounds
        public BitmapImage[] Back;

       
        string[] names = { "Joanne", "Tiffany", "Jackie" }; 
        public MainWindow()
        {
            InitializeComponent();
            
            Joanne = new Girl("Joanne", 0, 0, 0, null, null, null, null, null, null);
            Tiffany = new Girl("Tiffany", 0, 0, 0, null, null, null, null, null, null);
            Jackie = new Girl("Jackie", 0, 0, 0, null, null, null, null, null, null);
            theGirls = new BitmapImage[] {
                    new BitmapImage(new Uri(inThisProject + "Average-Normal.png")),
                    new BitmapImage(new Uri(inThisProject + "BadGirl-Normal.png")),
                    new BitmapImage(new Uri(inThisProject + "Nerdy-Normal.png")) };
            Back = new BitmapImage[] {
                    new BitmapImage(new Uri(inThisProject + "Bar.png")),
                    new BitmapImage(new Uri(inThisProject + "Beach.jpg")),
                    new BitmapImage(new Uri(inThisProject + "Campus.jpg")), 
                    new BitmapImage(new Uri(inThisProject + "Park.jpg")),
                    new BitmapImage(new Uri(inThisProject + "Mall.jpg")),
                    new BitmapImage(new Uri(inThisProject + "Library.png")),
                    new BitmapImage(new Uri(inThisProject + "Diner.jpg"))};

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.IsEnabled = true;
            timer.Tick += Myanus_Tick;
            diner.MouseDown += Diner_MouseDown;
            barimage.MouseDown += Barimage_MouseDown;
            libimage.MouseDown += Libimage_MouseDown;
            Girl0.MouseDown += Girl0_MouseDown;
            Girl1.MouseDown += Girl1_MouseDown;
            Girl2.MouseDown += Girl2_MouseDown;
        }

        //My timers
        DispatcherTimer walk;
        DispatcherTimer walk2;
        DispatcherTimer walk3;

        private void Girl2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (Walking.Visibility == Visibility.Hidden)
            {
                Walking.Visibility = Visibility.Visible;
            }
            walk = new DispatcherTimer();
            try
            {
                if (girlNum == 2)
                {
                    Walking.Visibility = Visibility.Hidden;
                    throw new GirlAlreadyHereException();
                }
                    Walking.Source = new BitmapImage(new Uri(inThisProject + "Walking.jpg"));
                    walk.Interval = TimeSpan.FromSeconds(5);
                    walk.IsEnabled = true;
                walk.Tick += Walk_Tick;
                   
            }
            catch (GirlAlreadyHereException)
            {
                MessageBox.Show("You're already with her");
            }
        }


        private void Walk_Tick(object sender, EventArgs e)
        {
            walk.IsEnabled = false;
            Walking.Visibility = Visibility.Hidden;
            salsa = prod.Next(0, 7);
            GirlOutput.Clear();
          
                    girlNum = 2;
                    girl.Source = theGirls[2];
                    Background.Source = Back[salsa];
                    Name.Text = names[2];
        }

        private void Girl1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Walking.Visibility == Visibility.Hidden)
            {
                Walking.Visibility = Visibility.Visible;
            }
            walk2 = new DispatcherTimer();
            try
            {
                if (girlNum == 1)
                {
                    Walking.Visibility = Visibility.Hidden;
                    throw new GirlAlreadyHereException();
                }
                    Walking.Source = new BitmapImage(new Uri(inThisProject + "Walking.jpg"));
                    walk2.Interval = TimeSpan.FromSeconds(5);
                    walk2.IsEnabled = true;
                    walk2.Tick += Walk2_Tick;
            }
            catch (GirlAlreadyHereException)
            {
                MessageBox.Show("You're already with her");
            }
        }

        private void Walk2_Tick(object sender, EventArgs e)
        {
            walk2.IsEnabled = false;
            GirlOutput.Clear();
            salsa = prod.Next(0, 7);
            Walking.Visibility = Visibility.Hidden;
            girlNum = 1;
            girl.Source = theGirls[1];
            Background.Source = Back[salsa];
            Name.Text = names[1];
        }

        private void Girl0_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Walking.Visibility == Visibility.Hidden)
            {
                Walking.Visibility = Visibility.Visible;
            }
            walk3 = new DispatcherTimer();
            try
            {
                if (girlNum == 0)
                {
                    Walking.Visibility = Visibility.Hidden;
                    throw new GirlAlreadyHereException();
                }
               
                    Walking.Source = new BitmapImage(new Uri(inThisProject + "Walking.jpg"));
                    walk3.Interval = TimeSpan.FromSeconds(5);
                    walk3.IsEnabled = true;
                    walk3.Tick += Walk3_Tick;
            }
            catch (GirlAlreadyHereException)
            {
                MessageBox.Show("You're already with her");
            }
        }

        private void Walk3_Tick(object sender, EventArgs e)
        {
            walk3.IsEnabled = false;
            GirlOutput.Clear();
            salsa = prod.Next(0, 7);
            Walking.Visibility = Visibility.Hidden;
            girlNum = 0;
            girl.Source = theGirls[0];
            Background.Source = Back[salsa];
            Name.Text = names[0];
        }

        private void Libimage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Background.Source = new BitmapImage(new Uri(inThisProject + "Library.png"));
            Canvas.SetTop(barimage, playground.ActualHeight - libimage.ActualHeight);
            Canvas.SetLeft(barimage, playground.ActualWidth - libimage.ActualWidth - 10);
            Canvas.SetTop(diner, (playground.ActualHeight - libimage.ActualHeight) - diner.ActualHeight);
            Canvas.SetLeft(diner, (playground.ActualWidth - libimage.ActualWidth) - 10);
            libimage.Visibility = Visibility.Hidden;
            Intro.Visibility = Visibility.Hidden;
            girlNum = 2;
            Girl2.Source = theGirls[girlNum];
            Name.Text = names[girlNum];
            girl.Source = theGirls[girlNum];
            GirlOutput.Text = "Oh, hello there";
        }

        private void Barimage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Background.Source = new BitmapImage(new Uri(inThisProject + "Bar.png"));
            Canvas.SetTop(libimage, playground.ActualHeight-libimage.ActualHeight);
            Canvas.SetLeft(libimage, playground.ActualWidth - libimage.ActualWidth -10 );
            Canvas.SetTop(diner, (playground.ActualHeight - libimage.ActualHeight) - diner.ActualHeight);
            Canvas.SetLeft(diner, (playground.ActualWidth - libimage.ActualWidth) - 10);
            barimage.Visibility = Visibility.Hidden;
            Intro.Visibility = Visibility.Hidden;
            girlNum = 1;
            Girl1.Source = theGirls[girlNum];
            Name.Text = names[girlNum];
            girl.Source = theGirls[girlNum];
            GirlOutput.Text = "Hey, you're in my way!";
        }

        private void Diner_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Background.Source = new BitmapImage(new Uri(inThisProject+ "Diner.jpg"));
            Canvas.SetTop(libimage, playground.ActualHeight - libimage.ActualHeight);
            Canvas.SetLeft(libimage, playground.ActualWidth - libimage.ActualWidth - 10);
            Canvas.SetTop(barimage, (playground.ActualHeight - libimage.ActualHeight) - diner.ActualHeight);
            Canvas.SetLeft(barimage, (playground.ActualWidth - libimage.ActualWidth) - 10);
            diner.Visibility = Visibility.Hidden;
            Intro.Visibility = Visibility.Hidden;
            girlNum = 0;
            Girl0.Source = theGirls[girlNum];
            Name.Text = names[girlNum];
            girl.Source = theGirls[girlNum];
            GirlOutput.Text = "Hey, that's where I usually sit";

        }

        private void Myanus_Tick(object sender, EventArgs e)
        {
            switch (selected)
            {
                case "batman":
                    current = Joanne;
                    break;
                default:
                    break;
            }
            /*
            Age.Content = current.Age;
            height.Content = current.Height;
            weight.Content = current.Weight;
            education.Content = current.Education;
            occupation.Content = current.Occupation;
            favbook.Content = current.FavouriteBook;
            hangout.Content = current.FavHangOut;
            breast.Content = current.BreastSize;
            eyecolor.Content = current.EyeColour;
            huniegirlname.Text = current.Name;
            agel.Content = "AGE:";
            heightl.Content = "HEIGHT:";
            weightl.Content = "WEIGHT:";
            educationl.Content = "EDUCATION:";
            occl.Content = "OCCUPATION";
            favbookl.Content = "FAVOURITE\n  BOOK:";
            hangoutl.Content = "FAVOURITE\nHANGOUT:";
            titsl.Content = "BREAST SIZE:";
            eyecl.Content = "EYE COLOUR:";
            */
        }
        int qw;
       
        public void stringify(int i)
        {
            Question quests = current.Q1[i];
            Random rng = new Random();
            qw = rng.Next(1, 4);
            int z = 0;
            Button a = new Button();
            Button b = new Button();
            Button c = new Button();
            a.Click += A_Click;
            b.Click += B_Click;
            c.Click += C_Click;
            List <Button> butts = new List<Button>() { a, b, c };
            foreach (Button item in butts)
            {
                playground.Children.Add(item);
                item.Height = 34;
                item.Width = 444;
                Canvas.SetLeft(item, 63);
                Canvas.SetTop(item, 162 + z);
                z += 56;
            }
            switch (qw)
            {
                case 1:
                    if (qw==1)
                    {
                        a.Content = quests.CorrectResponse;
                   
                        b.Content = quests.Incorrect1;
                        c.Content = quests.Incorrect2;
                    }break;
                case 2:
                    if (qw == 2)
                    {
                        a.Content = quests.Incorrect1;
                        b.Content = quests.CorrectResponse;
                        c.Content = quests.Incorrect2;
                    }
                    break;
                case 3:
                    if (qw == 3)
                    {
                        a.Content = quests.Incorrect1;
                        b.Content = quests.Incorrect2;
                        c.Content = quests.CorrectResponse;
                    }
                    break;
                default:
                    break;
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {

            switch (qw)
            {
                case 1:
                    if (qw == 1)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse2;
                    }
                    break;
                case 2:
                    if (qw == 2)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse3;
                    }
                    break;
                case 3:
                    if (qw == 3)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse1;
                    }
                    break;
                default:
                    break;
            }

        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            switch (qw)
            {
                case 1:
                    if (qw == 1)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse2;
                    }
                    break;
                case 2:
                    if (qw == 2)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse1;
                    }
                    break;
                case 3:
                    if (qw == 3)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse3;
                    }
                    break;
                default:
                    break;
            }
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            switch (qw)
            {
                case 1:
                    if (qw == 1)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse1;
                    }
                    break;
                case 2:
                    if (qw == 2)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse2;
                    }
                    break;
                case 3:
                    if (qw == 3)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse3;
                    }
                    break;
                default:
                    break;
            }
        }

        public enum charlie { a = 1, b, c }
    
      
    }
}

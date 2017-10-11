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
    public class GameAlreadyExistsException : ApplicationException
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
            Tiffany.Progress = Convert.ToInt32(one[0]);
            Jackie.Progress = Convert.ToInt32(two[0]);
        }
        public void displayStartupScreen()
        {
            Canvas candies = new Canvas();
            candies.VerticalAlignment = VerticalAlignment.Stretch;
            candies.HorizontalAlignment = HorizontalAlignment.Stretch;
            candies.Background = Brushes.Aquamarine;
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
            myfile.Close();
            myfile1.Close();
            myfile2.Close();


        }
        Girl Joanne;
        Girl Tiffany;
        Girl Jackie;
        Girl current;
        int jaPro = 0;
        int joPro = 0;
        int tifPro = 0;
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
            Joanne.Q1.Add(new Question("Oh, hello there", "Hi there:", "Um, I just wanted to say you’re beautiful:", "Are you sitting on the F4 button? Because that ass is refreshing…: ", "Hey, I’m Joa.", "Okay. Thanks. Bye.", "No, dude. Make like a tree and fuck off."));
            Joanne.Q1.Add(new Question("What type of music do you listen to?", "Blues: ", "Rap: ", "Rock: ", "(high 5’s) Awesome! It’s good knowing there’s another old soul out here.", "Really?? I can never hear what they’re saying.", "It’s not bad, I guess…"));
            Joanne.Q1.Add(new Question("What do you like to do?", "Just lounging: ", "Hiking: ", "Partying:", "Sometimes it’s all we ever need, right? ", ": That’s far too much exercise for my liking.", ": No one ever calls partying a hobby, you drunk."));
            Tiffany.Q1.Add(new Question("Hey, you're in my way!", "Are you sitting on the F4 button? Because that ass is refreshing…: ", "Hi there: ", "Um, I just wanted to say you’re beautiful:", "[laughs] Can’t believe that worked. You win. My name’s Tiffany.", "…", "Whatever, nerd. "));
            Tiffany.Q1.Add(new Question("What type of music do you listen to?", "Rock:", "Rap:", "Blues: ", "Right on!! ", "Right on!! ", "How old are you??? 60?"));
            Tiffany.Q1.Add(new Question("What do you like to do?", "Partying:  ", "Hiking: ", "Just lounging: ", "Hell yeah, you only live once. {pause} Great, I’m one of those millennials now, aren’t I?", "Uh, you’re more boring than I thought, which was pretty boring.", "You’re one of those loner couch potatoes, aren’t you?"));
            Jackie.Q1.Add(new Question("Hey, that's where I usually sit", "Um, I just wanted to say you’re beautiful: ", "Hi there: ", "Are you sitting on the F4 button? Because that ass is refreshing…: ", "[blushes] why, thank you. You aren’t half bad yourself. I’m Jaqs.", "Sorry, I’m really busy right now.", "…: Leave before I call campus security."));
            Jackie.Q1.Add(new Question("What type of music do you listen to?", "Rap: ", "Rock: ", "Blues: ", "Me, too. Sometimes it just sounds poetic, you know? ", "I don’t know, it’s all too grungy and heavy for me", "Yawn, that would put anyone to sleep"));
            Jackie.Q1.Add(new Question("What do you like to do?", "Hiking", "Just lounging: ", "Partying:", "The sounds of the birds and environment around is just so tranquil, right?", "That’s too unproductive for me. Might as well be dead.", "Eww. Deliberately destroying brain cells for a “good time” is the pinnacle of stupidity"));
            Joanne.Q1.Add(new Question("Whats your favourite Movie?", "Right?!! Adam Sandler is a comical genius. ", "The Notebook is my guilty pleasure: ", "The Conjuring, it’s a modern classic.: ", "Right?!! Adam Sandler is a comical genius. ", "Gag! I’d rather claw my eyes out.", "You’re calling a bunch of jumpscares a classic? Okay…"));
            Tiffany.Q1.Add(new Question("Whats your favourite Movie?", "The Notebook is my guilty pleasure: ", "Grown Ups, it’s just too funny: ", "The Conjuring, it’s a modern classic.: ", "No way, me too. I’m amazed by how many of my buttons you’re pressing.", "Sorry, I don’t waste my time with childish people.", "You’re one of those hipster horror nerds. Fantastic…"));
            Jackie.Q1.Add(new Question("Whats your favourite Movie ? ", "The Conjuring, it’s a modern classic.: ", "The Notebook is my guilty pleasure: ", "Grown Ups, it’s just too funny:", "Oh my gosh, it’s definitely in my Top 5 Movies of all time.", "I’ll never see myself enjoying that oversensitive garbage.", "Adam Sandler is the ingrown toenail of Holywood."));

            theGirls = new BitmapImage[] {
                    new BitmapImage(new Uri(inThisProject + "Average-Normal.png")),
                    new BitmapImage(new Uri(inThisProject + "BadGirl-Normal.png")),
                    new BitmapImage(new Uri(inThisProject + "Nerdy-Normal.png")),
                    new BitmapImage(new Uri(inThisProject + "Average-Happy.jpg")),
                    new BitmapImage(new Uri(inThisProject + "BadGirl-Happy.jpg")),
                    new BitmapImage(new Uri(inThisProject + "Nerdy-Happy.jpg")),
                    new BitmapImage(new Uri(inThisProject + "Average-Sad.png")),
                    new BitmapImage(new Uri(inThisProject + "BadHappy-Sad.jpg")),
                    new BitmapImage(new Uri(inThisProject + "Nerdy-Sad.png")) }
                    ;
                    
            Back = new BitmapImage[] {
                    new BitmapImage(new Uri(inThisProject + "Bar.png")),
                    new BitmapImage(new Uri(inThisProject + "Beach.jpg")),
                    new BitmapImage(new Uri(inThisProject + "Campus.jpg")), 
                    new BitmapImage(new Uri(inThisProject + "Park.jpg")),
                    new BitmapImage(new Uri(inThisProject + "Mall.jpg")),
                    new BitmapImage(new Uri(inThisProject + "Library.png")),
                    new BitmapImage(new Uri(inThisProject + "Diner.jpg"))};

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
        Button t = new Button();
        private void Girl2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            playground.Children.Remove(a);
            playground.Children.Remove(b);
            playground.Children.Remove(c);
            TextBox delta = new TextBox();
            delta.Height = 83;
            delta.Width = 497;
            playground.Children.Add(delta);
            Canvas.SetTop(delta, 504);
            Canvas.SetLeft(delta, 10);

            current = Jackie;
            playground.Children.Remove(t);
            playground.Children.Add(t);
            t.Height = 30;
            t.Width = 200;
            t.Content = "Talk";
            t.Click += T_Click;
            Canvas.SetTop(t, 250);
            Canvas.SetLeft(t, 10);
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

        private void T_Click(object sender, RoutedEventArgs e)
        {
            ques = qng.Next(1, current.Q1.Count);
            stringify(ques);
            playground.Children.Remove(t);
            a.Visibility = Visibility.Visible;
            b.Visibility = Visibility.Visible;
            c.Visibility = Visibility.Visible;
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
            playground.Children.Remove(a);
            playground.Children.Remove(b);
            playground.Children.Remove(c);
            TextBox delta = new TextBox();
            delta.Height = 83;
            delta.Width = 497;
            playground.Children.Add(delta);
            Canvas.SetTop(delta, 504);
            Canvas.SetLeft(delta, 10);

            current = Tiffany;
            playground.Children.Remove(t);
            playground.Children.Add(t);
            t.Height = 30;
            t.Width = 200;
            t.Content = "Talk";
            t.Click += T_Click;
            Canvas.SetTop(t, 250);
            Canvas.SetLeft(t, 10);
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
            playground.Children.Remove(a);
            playground.Children.Remove(b);
            playground.Children.Remove(c);
            TextBox delta = new TextBox();
            delta.Height = 83;
            delta.Width = 497;
            playground.Children.Add(delta);
            Canvas.SetTop(delta, 504);
            Canvas.SetLeft(delta, 10);

            current = Joanne;
            playground.Children.Remove(t);
            playground.Children.Add(t);
            t.Height = 30;
            t.Width = 200;
            t.Content = "Talk";
            t.Click += T_Click;
            Canvas.SetTop(t, 250);
            Canvas.SetLeft(t, 10);
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
            a.Visibility = Visibility.Visible;
            b.Visibility = Visibility.Visible;
            c.Visibility = Visibility.Visible;
            girl.Visibility = Visibility.Visible;
            Name.Visibility = Visibility.Visible;
            current = Jackie;
            stringify(0);
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
            a.Visibility = Visibility.Visible;
            b.Visibility = Visibility.Visible;
            c.Visibility = Visibility.Visible;
            girl.Visibility = Visibility.Visible;
            Name.Visibility = Visibility.Visible;
            current = Tiffany;
            stringify(0);
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
            a.Visibility = Visibility.Visible;
            b.Visibility = Visibility.Visible;
            c.Visibility = Visibility.Visible;
            girl.Visibility = Visibility.Visible;
            Name.Visibility = Visibility.Visible;
            current = Joanne;
            stringify(0);
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

        
        int qw;
        Button a = new Button();
        Button b = new Button();
        Button c = new Button();
        TextBox d = new TextBox();
        public void stringify(int i)
        {
            
            Save();
            Question quests = current.Q1[i];
            Random rng = new Random();
            qw = rng.Next(1, 4);
            int z = 0;
            //if (d.Parent!=playground)
            //{
            playground.Children.Remove(d);
                playground.Children.Add(d);
            //}
            d.Height = 83;
            d.Width = 497;
            Canvas.SetTop(d, 504);
            Canvas.SetLeft(d, 10);
            d.Text = $"{quests.Quest}";
            a.Click += A_Click;
            b.Click += B_Click;
            c.Click += C_Click;
            List <Button> butts = new List<Button>() { a, b, c };
            foreach (Button item in butts)
            {
                playground.Children.Remove(item);
                playground.Children.Add(item);
                item.Height = 36;
                item.Width = 400;
                Canvas.SetLeft(item, 10);
                Canvas.SetTop(item, 10 + z);
                z += 46;
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
        int helper = 0;
        private void C_Click(object sender, RoutedEventArgs e)
        {
            playground.Children.Remove(t);
            playground.Children.Add(t);
            if (helper==0)
            {
                helper++;
            }
            else
            {
                helper = 0;
            }
            a.Visibility = Visibility.Hidden;
            b.Visibility = Visibility.Hidden;
            c.Visibility = Visibility.Hidden;
            switch (qw)
            {
                case 1:
                    if (qw == 1)
                    {
                        TextBox d = new TextBox();
                        playground.Children.Add(d);
                        d.Height = 83;
                        d.Width = 497;
                        Canvas.SetTop(d, 504);
                        Canvas.SetLeft(d, 10);
                        d.Text = current.Q1[ques].HerResponse2;
                        switch (current.Name)
                        {
                            case "Joanne":
                                girl.Source = theGirls[6];
                                break;
                            case "Tiffany":
                                girl.Source = theGirls[7];
                                break;
                            case "jackie":
                                girl.Source = theGirls[8];
                                break;
                                ;
                            default:
                                break;
                        }
                    }
                    break;
                case 2:
                    if (qw == 2)
                    {
                        TextBox d = new TextBox();
                        playground.Children.Add(d);
                        d.Height = 83;
                        d.Width = 497;
                        Canvas.SetTop(d, 504);
                        Canvas.SetLeft(d, 10);
                        d.Text = current.Q1[ques].HerResponse3;
                        switch (current.Name)
                        {
                            case "Joanne":
                                girl.Source = theGirls[6];
                                break;
                            case "Tiffany":
                                girl.Source = theGirls[7];
                                break;
                            case "jackie":
                                girl.Source = theGirls[8];
                                break;
                                ;
                            default:
                                break;
                        }
                    }
                    break;
                case 3:
                    if (qw == 3)
                    {
                        TextBox d = new TextBox();
                        playground.Children.Add(d);
                        d.Height = 83;
                        d.Width = 497;
                        Canvas.SetTop(d, 504);
                        Canvas.SetLeft(d, 10);
                        d.Text = current.Q1[ques].HerResponse1;
                        current.Progress+=helper;
                        helper++;
                        switch (current.Name)
                        {
                            case "Joanne":
                                girl.Source = theGirls[3];
                                break;
                            case "Tiffany":
                                girl.Source = theGirls[4];
                                break;
                            case "jackie":
                                girl.Source = theGirls[5];
                                break;
                                ;
                            default:
                                break;
                        }

                        break;
                    }
                    break;
               
            }

        }
        

        private void B_Click(object sender, RoutedEventArgs e)
        {
            playground.Children.Remove(t);
            playground.Children.Add(t);
            a.Visibility = Visibility.Hidden;
            b.Visibility = Visibility.Hidden;
            c.Visibility = Visibility.Hidden;
            if (helper == 0)
            {
                helper++;
            }
            else
            {
                helper = 0;
            }
            switch (qw)
            {
                case 1:
                    if (qw == 1)
                    {
                        TextBox d = new TextBox();
                        playground.Children.Add(d);
                        d.Height = 83;
                        d.Width = 497;
                        Canvas.SetTop(d, 504);
                        Canvas.SetLeft(d, 10);
                        d.Text = current.Q1[ques].HerResponse2;
                        switch (current.Name)
                        {
                            case "Joanne":
                                girl.Source = theGirls[6];
                                break;
                            case "Tiffany":
                                girl.Source = theGirls[7];
                                break;
                            case "jackie":
                                girl.Source = theGirls[8];
                                break;
                                ;
                            default:
                                break;
                        }
                    }
                    break;
                case 2:
                    if (qw == 2)
                    {
                        TextBox d = new TextBox();
                        playground.Children.Add(d);
                        d.Height = 83;
                        d.Width = 497;
                        Canvas.SetTop(d, 504);
                        Canvas.SetLeft(d, 10);
                        d.Text = current.Q1[ques].HerResponse1;
                        current.Progress+=helper;
                        helper++;
                        switch (current.Name)
                        {
                            case "Joanne":
                                girl.Source = theGirls[3];
                                break;
                            case "Tiffany":
                                girl.Source = theGirls[4];
                                break;
                            case "jackie":
                                girl.Source = theGirls[5];
                                break;
                                ;
                            default:
                                break;
                        }

                    }
                    break;
                case 3:
                    if (qw == 3)
                    {
                        TextBox d = new TextBox();
                        playground.Children.Add(d);
                        d.Height = 83;
                        d.Width = 497;
                        Canvas.SetTop(d, 504);
                        Canvas.SetLeft(d, 10);
                        d.Text = current.Q1[ques].HerResponse3;
                        switch (current.Name)
                        {
                            case "Joanne":
                                girl.Source = theGirls[6];
                                break;
                            case "Tiffany":
                                girl.Source = theGirls[7];
                                break;
                            case "jackie":
                                girl.Source = theGirls[8];
                                break;
                                ;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            playground.Children.Remove(t);
            playground.Children.Add(t);
            a.Visibility = Visibility.Hidden;
            b.Visibility = Visibility.Hidden;
            c.Visibility = Visibility.Hidden;
            if (helper == 0)
            {
                helper++;
            }
            else if(helper==2)
            {
                helper = 0;
            }
            switch (qw)
            {
                case 1:
                    if (qw == 1)
                    {
                        TextBox d = new TextBox();
                        playground.Children.Add(d);
                        d.Height = 83;
                        d.Width = 497;
                        Canvas.SetTop(d, 504);
                        Canvas.SetLeft(d, 10);
                        d.Text = current.Q1[ques].HerResponse1;
                        current.Progress+=helper;
                        helper++;
                        switch (current.Name)
                        {
                            case "Joanne":
                                girl.Source = theGirls[3];
                                break;
                            case "Tiffany":
                                girl.Source = theGirls[4];
                                break;
                            case "jackie":
                                girl.Source = theGirls[5];
                                break;
                                ;                            default:
                                break;
                        }
                       
                    }
                    break;
                case 2:
                    if (qw == 2)
                    {
                        TextBox d = new TextBox();
                        playground.Children.Add(d);
                        d.Height = 83;
                        d.Width = 497;
                        Canvas.SetTop(d, 504);
                        Canvas.SetLeft(d, 10);
                        d.Text = current.Q1[ques].HerResponse2;
                        switch (current.Name)
                        {
                            case "Joanne":
                                girl.Source = theGirls[6];
                                break;
                            case "Tiffany":
                                girl.Source = theGirls[7];
                                break;
                            case "jackie":
                                girl.Source = theGirls[8];
                                break;
                                ;
                            default:
                                break;
                        }
                    }
                    break;
                case 3:
                    if (qw == 3)
                    {
                        TextBox d = new TextBox();
                        playground.Children.Add(d);
                        d.Height = 83;
                        d.Width = 497;
                        Canvas.SetTop(d, 504);
                        Canvas.SetLeft(d, 10);
                        d.Text = current.Q1[ques].HerResponse3;
                        switch (current.Name)
                        {
                            case "Joanne":
                                girl.Source = theGirls[6];
                                break;
                            case "Tiffany":
                                girl.Source = theGirls[7];
                                break;
                            case "jackie":
                                girl.Source = theGirls[8];
                                break;
                                ;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        DispatcherTimer loadNewGame = new DispatcherTimer();
        public enum charlie { a = 1, b, c }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            
            New.Visibility = Visibility.Hidden;
            Loada.Visibility = Visibility.Hidden;
            try
            {
                if (Joanne.Progress != 0 || Jackie.Progress != 0 || Tiffany.Progress != 0) throw new GameAlreadyExistsException();
               
                if (Walking.Visibility == Visibility.Hidden)
                {
                    Walking.Visibility = Visibility.Visible;
                }
                loadNewGame.IsEnabled = true;
                loadNewGame.Interval = TimeSpan.FromSeconds(5);
                loadNewGame.Tick += LoadNewGame_Tick;



            }
            catch (GameAlreadyExistsException)
            {

                MessageBox.Show("There is already a saved file ");
                Button a = new Button();
                Button b = new Button();
                a.Content = "Start anyway";
                b.Content = "Continue old save";
                a.Height = 100;
                b.Height = 100;
                a.Width = 300;
                b.Width = 300;
                StartupScreeen.Children.Add(a);
                StartupScreeen.Children.Add(b);
                Canvas.SetLeft(b, (StartupScreeen.ActualWidth) - 325);
                Canvas.SetTop(b, (StartupScreeen.ActualHeight / 2) - (b.ActualHeight / 2));
                Canvas.SetTop(a, StartupScreeen.ActualHeight / 2);
                Canvas.SetLeft(a, 25);
                a.Click += A_Click1;
                b.Click += B_Click1;
            }
            
        }

        private void B_Click1(object sender, RoutedEventArgs e)
        {
            //Load();
           
            StartupScreeen.Visibility = Visibility.Hidden;
            playground.Visibility = Visibility.Visible;
            barimage.Visibility = Visibility.Hidden;
            libimage.Visibility = Visibility.Hidden;
            diner.Visibility = Visibility.Hidden;
            girl.Visibility = Visibility.Visible;
            girl.Source = theGirls[0];
            Background.Visibility = Visibility.Visible;
            Background.Source= new BitmapImage(new Uri(inThisProject + "Library.png"));
            Girl0.Source = theGirls[0];
            Girl0.Visibility = Visibility.Visible;
            Girl1.Source = theGirls[1];
            Girl1.Visibility = Visibility.Visible;
            Girl2.Source = theGirls[2];
            Girl2.Visibility = Visibility.Visible;
            playground.Children.Add(d);
            
        }

        private void A_Click1(object sender, RoutedEventArgs e)
        {
            Walking.Visibility = Visibility.Visible;
            Walking.Source = new BitmapImage(new Uri(inThisProject + "Walking.jpg"));

            Joanne.Progress = 0;
            Jackie.Progress = 0;
            Tiffany.Progress = 0;
            loadNewGame.IsEnabled = true;
            loadNewGame.Interval = TimeSpan.FromSeconds(5);
            loadNewGame.Tick += LoadNewGame_Tick;
            
            StartupScreeen.Visibility = Visibility.Hidden;
           
            
            playground.Visibility = Visibility.Visible;
            
        }

        private void LoadNewGame_Tick(object sender, EventArgs e)
        {
            
            loadNewGame.IsEnabled = false;
            StartupScreeen.Visibility = Visibility.Hidden;
            playground.Visibility = Visibility.Visible;
            Walking.Visibility = Visibility.Hidden;

        }

        private void Loada_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Load();
                StartupScreeen.Visibility = Visibility.Hidden;
                playground.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message} - starting new game");
                StartupScreeen.Visibility = Visibility.Hidden;
                playground.Visibility = Visibility.Visible;
            }
        }
    }
}

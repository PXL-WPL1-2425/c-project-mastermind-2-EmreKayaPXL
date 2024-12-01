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
using System.Windows.Threading;

namespace Mastermind2_EmreKayaPXL
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        DateTime clicked;
        TimeSpan elapsedTime;
        int attempts = 1;
        int score = 100;
        int correctTotalColor1 = 0;
        int correctTotalColor2 = 0;
        int correctTotalColor3 = 0;
        int correctTotalColor4 = 0;
        MessageBoxResult messageBoxResult;
        int MasterMindStrenghtNumber = 0;
        string randomColors;

        public MainWindow()
        {
            InitializeComponent();
            titleRandomColors();
            UpdateTitle();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Timer_Tick;
        }

        private void HistoryColorsAttempts()
        {
            List<Label> Rij1 = new List<Label> { A1, B1, C1, D1 };
            List<Label> Rij2 = new List<Label> { A2, B2, C2, D2 };
            List<Label> Rij3 = new List<Label> { A3, B3, C3, D3 };
            List<Label> Rij4 = new List<Label> { A4, B4, C4, D4 };
            List<Label> Rij5 = new List<Label> { A5, B5, C5, D5 };
            List<Label> Rij6 = new List<Label> { A6, B6, C6, D6 };
            List<Label> Rij7 = new List<Label> { A7, B7, C7, D7 };
            List<Label> Rij8 = new List<Label> { A8, B8, C8, D8 };
            List<Label> Rij9 = new List<Label> { A9, B9, C9, D9 };
            List<Label> Rij10 = new List<Label> { A10, B10, C10, D10 };

            List<Label> kolomHoofd = new List<Label> { label1, label2, label3, label4 };

            switch (attempts)
            {
                case 2:
                    for (int i = 0; i < 4; i++)
                    {
                        Rij1[i].Background = kolomHoofd[i].Background;
                        Rij1[i].BorderBrush = kolomHoofd[i].BorderBrush;
                    }
                    break;
                case 3:
                    for (int i = 0; i < 4; i++)
                    {
                        Rij2[i].Background = kolomHoofd[i].Background;
                        Rij2[i].BorderBrush = kolomHoofd[i].BorderBrush;
                    }
                    break;
                case 4:
                    for (int i = 0; i < 4; i++)
                    {
                        Rij3[i].Background = kolomHoofd[i].Background;
                        Rij3[i].BorderBrush = kolomHoofd[i].BorderBrush;
                    }
                    break;
                case 5:
                    for (int i = 0; i < 4; i++)
                    {
                        Rij4[i].Background = kolomHoofd[i].Background;
                        Rij4[i].BorderBrush = kolomHoofd[i].BorderBrush;
                    }
                    break;
                case 6:
                    for (int i = 0; i < 4; i++)
                    {
                        Rij5[i].Background = kolomHoofd[i].Background;
                        Rij5[i].BorderBrush = kolomHoofd[i].BorderBrush;
                    }
                    break;
                case 7:
                    for (int i = 0; i < 4; i++)
                    {
                        Rij6[i].Background = kolomHoofd[i].Background;
                        Rij6[i].BorderBrush = kolomHoofd[i].BorderBrush;
                    }
                    break;
                case 8:
                    for (int i = 0; i < 4; i++)
                    {
                        Rij7[i].Background = kolomHoofd[i].Background;
                        Rij7[i].BorderBrush = kolomHoofd[i].BorderBrush;
                    }
                    break;
                case 9:
                    for (int i = 0; i < 4; i++)
                    {
                        Rij8[i].Background = kolomHoofd[i].Background;
                        Rij8[i].BorderBrush = kolomHoofd[i].BorderBrush;
                    }
                    break;
                case 10:
                    for (int i = 0; i < 4; i++)
                    {
                        Rij9[i].Background = kolomHoofd[i].Background;
                        Rij9[i].BorderBrush = kolomHoofd[i].BorderBrush;
                    }
                    break;
                case 11:
                    for (int i = 0; i < 4; i++)
                    {
                        Rij10[i].Background = kolomHoofd[i].Background;
                        Rij10[i].BorderBrush = kolomHoofd[i].BorderBrush;
                    }
                    ToggleDebug();

                    messageBoxResult = MessageBox.Show($"U heeft verloren!\nScore: {score}/100\nAantal pogingen over: {10 - attempts}" +
                        $"\nWilt u nog eens proberen?", "winnende bericht", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        score = 100;
                        ToggleDebug();
                        AllesRessetten();
                        UpdateTitle();
                        randomColorBuilder.Clear();
                        titleRandomColors();
                    }
                    else
                    {
                        this.Close();
                    }
                    break;
                default:
                    break;
            }
        }
        private void AllesRessetten()
        {
            List<Label> Rij1 = new List<Label> { A1, B1, C1, D1 };
            List<Label> Rij2 = new List<Label> { A2, B2, C2, D2 };
            List<Label> Rij3 = new List<Label> { A3, B3, C3, D3 };
            List<Label> Rij4 = new List<Label> { A4, B4, C4, D4 };
            List<Label> Rij5 = new List<Label> { A5, B5, C5, D5 };
            List<Label> Rij6 = new List<Label> { A6, B6, C6, D6 };
            List<Label> Rij7 = new List<Label> { A7, B7, C7, D7 };
            List<Label> Rij8 = new List<Label> { A8, B8, C8, D8 };
            List<Label> Rij9 = new List<Label> { A9, B9, C9, D9 };
            List<Label> Rij10 = new List<Label> { A10, B10, C10, D10 };

            List<Label> kolomHoofd = new List<Label> { label1, label2, label3, label4 };
            ComboBox1.SelectedIndex = -1;
            ComboBox2.SelectedIndex = -1;
            ComboBox3.SelectedIndex = -1;
            ComboBox4.SelectedIndex = -1;

            for (int i = 0; i < 4; i++)
            {
                kolomHoofd[i].Background = Brushes.Transparent;
                kolomHoofd[i].BorderBrush = Brushes.Transparent;

                Rij1[i].Background = Brushes.Transparent;
                Rij1[i].BorderBrush = Brushes.Transparent;

                Rij2[i].Background = Brushes.Transparent;
                Rij2[i].BorderBrush = Brushes.Transparent;

                Rij3[i].Background = Brushes.Transparent;
                Rij3[i].BorderBrush = Brushes.Transparent;

                Rij4[i].Background = Brushes.Transparent;
                Rij4[i].BorderBrush = Brushes.Transparent;

                Rij5[i].Background = Brushes.Transparent;
                Rij5[i].BorderBrush = Brushes.Transparent;

                Rij6[i].Background = Brushes.Transparent;
                Rij6[i].BorderBrush = Brushes.Transparent;

                Rij7[i].Background = Brushes.Transparent;
                Rij7[i].BorderBrush = Brushes.Transparent;

                Rij8[i].Background = Brushes.Transparent;
                Rij8[i].BorderBrush = Brushes.Transparent;

                Rij9[i].Background = Brushes.Transparent;
                Rij9[i].BorderBrush = Brushes.Transparent;

                Rij10[i].Background = Brushes.Transparent;
                Rij10[i].BorderBrush = Brushes.Transparent;
            }
            resultTextBlock.Text = "";
            scoreTextBox.Text = $" Score = 100/100";
            clicked = DateTime.Now;
            timer.Start();
            timerLabel.Content = "";
            correctTotalColor1 = 0;
            correctTotalColor2 = 0;
            correctTotalColor3 = 0;
            correctTotalColor4 = 0;
            attempts = 1;
            label1.Content = "Kleur 1";
            label2.Content = "Kleur 2";
            label3.Content = "Kleur 3";
            label4.Content = "Kleur 4";
            MasterMindStrenghtNumber = 0;
        }

        /// </summary> StopCountdown(): de timer stopt <summary>
        private void StopCountdown()
        {
            timer.Stop();
        }
        /// <summary> StartCountdown(): Start de timer, poging stijgt met 1 en de titel wordt geupdatet </summary>
        private void StartCountDown()
        {
            timer.Start();
            attempts++;
            UpdateTitle();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime = DateTime.Now - clicked;
            timerLabel.Content = $"{elapsedTime.Seconds} : {elapsedTime.Milliseconds.ToString().PadLeft(3, '0')}";

            if (correctTotalColor1 >= 1 && correctTotalColor2 >= 1 && correctTotalColor3 >= 1 && correctTotalColor4 >= 1)
            {
                attempts--;
                UpdateTitle();
                ToggleDebug();

                messageBoxResult = MessageBox.Show($"U heeft gewonnen!\nScore: {score}/100\nAantal pogingen over: {10 - attempts}" +
                    $"\nWilt u nog eens proberen?", "winnende bericht", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    score = 100;
                    ToggleDebug();
                    AllesRessetten();
                    UpdateTitle();
                    randomColorBuilder.Clear();
                    titleRandomColors();
                }
                else
                {
                    this.Close();
                }
                return;
            }
            else if (attempts > 10)
            {
                timerLabel.Content = "";
            }
            else if(elapsedTime.Seconds >= 10)
            {
                timer.Stop();
                MessageBox.Show("Te laat 10 seconden zijn voorbij, er wordt 1 poging toegevoegd");
                clicked = DateTime.Now;
                StartCountDown();
            }
            else if (elapsedTime.Seconds >= 9)
            {
                timerLabel.Background = Brushes.Red;
            }
            else if (elapsedTime.Seconds >= 7)
            {
                timerLabel.Background = Brushes.DarkOrange;
            }
            else if (elapsedTime.Seconds >= 4)
            {
                timerLabel.Background = Brushes.DarkGreen;
            }
            else
            {
                timerLabel.Background = Brushes.Transparent;
            }
        }

        StringBuilder randomColorBuilder;
        private void titleRandomColors()
        { 
            string[] colors = { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
            Random random = new Random();
            randomColorBuilder = new StringBuilder("Mastermind kleur: ");

            for (int i = 0; i < 4; i++)
            {

                    int randomIndex = random.Next(0, colors.Length);
                    randomColorBuilder.Append(colors[randomIndex]);
                    if (i < 3)
                    {
                        randomColorBuilder.Append(", ");
                    }
            }
            randomColors = randomColorBuilder.ToString();
            randomColorsTextBox.Text = randomColors;    
        }

        private void UpdateTitle()
        {
            this.Title = $" Mastermind             poging {attempts}/10";
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.SelectedItem is ComboBoxItem ComboBox1Item)  // als item is geselecteerd
            {
                if (ComboBox1Item.Background is SolidColorBrush Kleur) // dan: kleur borstel naar achtergrondskleur van geselecteerde Item
                {
                    label1.Background = Kleur;   //label de keur geven van achtergrondskleur van geselecteerde Item  
                    label1.Content = ComboBox1Item.Content.ToString();
                }
            }
        }
        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox2.SelectedItem is ComboBoxItem ComboBox2Item)
            {
                if (ComboBox2Item.Background is SolidColorBrush Kleur)
                {
                    label2.Background = Kleur;
                    label2.Content = ComboBox2Item.Content.ToString();
                }
            }
        }
        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox3.SelectedItem is ComboBoxItem ComboBox3Item)
            {
                if (ComboBox3Item.Background is SolidColorBrush Kleur)
                {
                    label3.Background = Kleur;
                    label3.Content = ComboBox3Item.Content.ToString();
                }
            }
        }
        private void ComboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox4.SelectedItem is ComboBoxItem ComboBox4Item)
            {
                if (ComboBox4Item.Background is SolidColorBrush Kleur)
                {
                    label4.Background = Kleur;
                    label4.Content = ComboBox4Item.Content.ToString();
                }
            }
        }

        string label1Color;
        string label2Color;
        string label3Color;
        string label4Color;
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {

            StartCountDown();
            clicked = DateTime.Now;

            label1.BorderBrush = Brushes.LightGray;
            label2.BorderBrush = Brushes.LightGray;
            label3.BorderBrush = Brushes.LightGray;
            label4.BorderBrush = Brushes.LightGray;

            string[] titleColors = randomColorsTextBox.Text.Split(':')[1].Split(',');


            string label1Color = label1.Content.ToString();
            string label2Color = label2.Content.ToString();
            string label3Color = label3.Content.ToString();
            string label4Color = label4.Content.ToString();

            MasterMindStrenghtNumber = 0;
            if (randomColorsTextBox.Text.Contains(label1Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[0].Contains(label1Color))
                {
                    label1.BorderBrush = Brushes.DarkRed;
                    correctTotalColor1 = 1;
                }
                else
                {
                    label1.BorderBrush = Brushes.Wheat;
                    score -= 1;
                    correctTotalColor1 = 0;
                }
            }
            else
            {
                score -= 2;
                correctTotalColor1 = 0;
            }
            if (randomColorsTextBox.Text.Contains(label2Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[1].Contains(label2Color))
                {
                    label2.BorderBrush = Brushes.DarkRed;
                    correctTotalColor2 = 1;
                }
                else
                {
                    label2.BorderBrush = Brushes.Wheat;
                    score -= 1;
                    correctTotalColor2 = 0;
                }
            }
            else
            {
                score -= 2;
                correctTotalColor2 = 0;
            }
            if (randomColorsTextBox.Text.Contains(label3Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[2].Contains(label3Color))
                {
                    label3.BorderBrush = Brushes.DarkRed;
                    correctTotalColor3 = 1;
                }
                else
                {
                    label3.BorderBrush = Brushes.Wheat;
                    score -= 1;
                    correctTotalColor3 = 0;
                }
            }
            else
            {
                score -= 2;
                correctTotalColor3 = 0;
            }
            if (randomColorsTextBox.Text.Contains(label4Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[3].Contains(label4Color))
                {
                    label4.BorderBrush = Brushes.DarkRed;
                    correctTotalColor4 = 1;
                }
                else
                {
                    label4.BorderBrush = Brushes.Wheat;
                    score -= 1;
                    correctTotalColor4 = 0;
                }
            }
            else
            {
                score -= 2;
                correctTotalColor4 = 0;
            }

            switch (MasterMindStrenghtNumber)
            {
                case 4:
                    resultTextBlock.Text = "4 kleuren komen voor";
                    break;
                case 3:
                    resultTextBlock.Text = "3 kleuren komen voor";
                    break;
                case 2:
                    resultTextBlock.Text = "2 kleuren komen voor";
                    break;
                case 1:
                    resultTextBlock.Text = "1 kleur komt voor";
                    break;
                default:
                    resultTextBlock.Text = "Niet de juiste kleuren gebruikt";
                    break;
            }
            scoreTextBox.Text = $" Score = {score}/100";
            HistoryColorsAttempts();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clicked = DateTime.Now;
            timer.Start();
            scoreTextBox.Text = $" Score = 100/100";
        }

        private bool isInDebug = false;

        private void Window_Keydown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.F12))
            {
                ToggleDebug();
            }
        }
        /// <summary> ToggleDebug(): isInDebug waarde wordt omgedraaid, dus true wordt false en false wordt true. 
        /// Bij false is randomColorsTextBox zichtbaar en bij true niet.  </summary>
        private void ToggleDebug()
        {
            isInDebug = !isInDebug;

            if (isInDebug)
            {
                randomColorsTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                randomColorsTextBox.Visibility = Visibility.Collapsed;
            }
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs uit)
        {
        MessageBoxResult closeTheWindow = MessageBox.Show("Bent u zeker Om het spel te sluiten?","VensterSluiten", MessageBoxButton.YesNo);
  
            if (closeTheWindow == MessageBoxResult.Yes )
            {
                uit.Cancel = false;
            }
            else
            {
                uit.Cancel = true;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs k)
        {
            StopCountdown();
            MessageBox.Show("Kies de juiste kleur die op de juiste plaats hoort." +
                "\nRode rand betekent dat de kleur op de juiste plaats staat." +
                "\nLichte beige rand betekent dat de kleur juist is maar op de verkeerde plaats staat");
            clicked = DateTime.Now; 
            timer.Start();
        }
    }
}
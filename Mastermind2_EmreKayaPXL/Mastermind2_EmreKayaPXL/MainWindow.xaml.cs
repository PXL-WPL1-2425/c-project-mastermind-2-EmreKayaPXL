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
        //StringBuilder sb = new StringBuilder();
        private DispatcherTimer timer = new DispatcherTimer();
        DateTime clicked;
        TimeSpan elapsedTime;
        int attempts = 1;

        public MainWindow()
        {
            InitializeComponent();
            titleRandomColors();
            UpdateTitle();

            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Timer_Tick;

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

            if (elapsedTime.Seconds >= 60)
            {
                timer.Stop();
                timerLabel.Background = Brushes.Red;
                MessageBox.Show("Te laat 10 seconden zijn voorbij, er wordt 1 poging toegevoegd");
                clicked = DateTime.Now;
                StartCountDown();
            }
            else
            {
                timerLabel.Background = Brushes.Transparent;
            }

            if (elapsedTime.Seconds >= 7)
            {
                timerLabel.Background = Brushes.Orange;
            }
        }

        StringBuilder randomColorBuilder = new StringBuilder("Mastermind kleur: ");
        private void titleRandomColors()
        {
            string[] colors = { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                if (i < 4)
                {
                    int randomIndex = random.Next(0, colors.Length);
                    randomColorBuilder.Append(colors[randomIndex]);
                    if (i < 3)
                    {
                        randomColorBuilder.Append(", ");
                    }
                }
            }
            string randomColors = randomColorBuilder.ToString();
            randomColorsTextBox.Text = randomColors;
        }

        private void UpdateTitle()
        {
            this.Title = $" Mastermind             poging {attempts}/10";

            if (attempts > 9)
            {
                ToggleDebug();
                MessageBox.Show("Je hebt 10 pogingen gedaan, dus je bent verloren.");
                this.Close();
            }
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

            int MasterMindStrenghtNumber = 0;

            string label1Color = label1.Content.ToString();
            string label2Color = label2.Content.ToString();
            string label3Color = label3.Content.ToString();
            string label4Color = label4.Content.ToString();

            if (randomColorsTextBox.Text.Contains(label1Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[0].Contains(label1Color))
                {
                    label1.BorderBrush = Brushes.DarkRed;
                }
                else
                {
                    label1.BorderBrush = Brushes.Wheat;
                }
            }
            if (randomColorsTextBox.Text.Contains(label2Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[1].Contains(label2Color))
                {
                    label2.BorderBrush = Brushes.DarkRed;
                }
                else
                {
                    label2.BorderBrush = Brushes.Wheat;
                }
            }
            if (randomColorsTextBox.Text.Contains(label3Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[2].Contains(label3Color))
                {
                    label3.BorderBrush = Brushes.DarkRed;
                }
                else
                {
                    label3.BorderBrush = Brushes.Wheat;
                }
            }

            if (randomColorsTextBox.Text.Contains(label4Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[3].Contains(label4Color))
                {
                    label4.BorderBrush = Brushes.DarkRed;
                }
                else
                {
                    label4.BorderBrush = Brushes.Wheat;
                }
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

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clicked = DateTime.Now;
            timer.Start();
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
    }
}

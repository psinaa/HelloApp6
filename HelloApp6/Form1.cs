using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HelloApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            string s2 = textBox4.Text;
            string s3 = textBox6.Text;

            int a1, a2, a3;

            if (int.TryParse(s1, out a1))
            {
                MyCollection<int> myIntCollection = new MyCollection<int>();
                myIntCollection.Add(1);
                myIntCollection.Add(2);
                myIntCollection.Add(3);
                myIntCollection.Add(4);
                if (a1 != 0) myIntCollection.Add(a1);
                if (int.TryParse(s2, out a2) && a2 != 0) myIntCollection.Remove(a2);
                if (int.TryParse(s3, out a3) && a3 != 0) myIntCollection.Clear();
                textBox8.Text = string.Join(", ", myIntCollection.ToArray());
            }

        }

        public class MyCollection<T>
        {
            private List<T> items;

            public MyCollection()
            {
                items = new List<T>();
            }

            public void Add(T item)
            {
                items.Add(item);
            }

            public void Clear()
            {
                items.Clear();
            }

            public void Remove(T item)
            {
                items.Remove(item);
            }

            public int Count
            {
                get
                {
                    return items.Count;
                }
            }

            public T[] ToArray()
            {
                return items.ToArray();
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            List<Person> people = new List<Person>();
            string s11 = textBox10.Text;
            string s12 = textBox12.Text;
            string s13 = textBox14.Text;
            people.Add(new Person(s11, s12, s13));
            string peopleInfo = "";
            foreach (Person person in people)
            {
                peopleInfo += $"Имя: {person.Name}, Возраст: {person.Age}, Адрес: {person.Address}\r\n";
            }

            textBox15.Text = peopleInfo;
        }
        public class Person
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string Address { get; set; }

            public Person(string name, string age, string address)
            {
                Name = name;
                Age = age;
                Address = address;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s11 = textBox10.Text;
            string s12 = textBox12.Text;
            string s13 = textBox14.Text;
            Person newPerson = new Person(s11, s12, s13);
            Dictionary<string, string> personInfo = GetPersonInfoDictionary(newPerson);
            textBox16.Clear();
            foreach (var kvp in personInfo)
            {
                textBox16.AppendText($"{kvp.Key}: {kvp.Value}\r\n");
            }
        }
        private Dictionary<string, string> GetPersonInfoDictionary(Person person)
        {
            Dictionary<string, string> personInfo = new Dictionary<string, string>
    {
        { "Имя", person.Name },
        { "Возраст", person.Age.ToString() },
        { "Адрес", person.Address }
    };
            return personInfo;
        }
    }
}
using diarything;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace diarything
{
    internal class Note
    {
        public DateTime Date;
        public string Name;
        public string Description;
        public DateOnly BestBefore;
        public string Notabene;
    }

}

internal class Program
{
    static Note Note1 = new Note()
    {
        Date = new DateTime(2015, 7, 2, 18, 30, 47),
        Name = "поплавать без дождя",
        Description = "Здесь слишком много дождливых дней, в которые опасно плавать. Я должна хотя бы раз поплавать в бездождевом море, даже если мне придется плавать ночью.",
        BestBefore = new DateOnly(2015, 7, 24),
        Notabene = "Если я буду еще хотя бы день сидеть безвылазно и смотреть, как из-за дождя уносит стулья и одежду таких же неудачилвых, как я, туристов, то пойду пить чачу.",
    };
    static Note NoteA = new Note()
    {
        Date = new DateTime(2015, 7, 2, 22, 08, 59),
        Name = "Посчитать количество недождливых дней",
        Description = "Мне еще здесь сидеть больше недели. Сколько дней без дождя я смогу посчитать?",
        BestBefore = new DateOnly(2015, 7, 24),
        Notabene = "да, здесь НАСТОЛько нечего делать"
    };
    static Note NoteB = new Note()
    {
        Date = new DateTime(2015, 7, 2, 23, 49, 01),
        Name = "Закачать еще книг",
        Description = "Закачать м н о г о книг когда опять появится интернет. Больше 20. ",
        BestBefore = new DateOnly(2015, 7, 5),
        Notabene = "нечего добавить. просто нельзя забыть сделать"
    };

    static Note Note2 = new Note()
    {
        Date = new DateTime(2015, 9, 16, 14, 12, 03),
        Name = "Тест",
        Description = "Тест по русскому языку, причастия и наречия. Что-то про исключения??",
        BestBefore = new DateOnly(2015, 9, 18),
        Notabene = "Уточнить тот кусок про исключения у кого-нибудь"
    };
    static Note NoteC = new Note()
    {
        Date = new DateTime(2015, 9, 16, 15, 32, 10),
        Name = "Купить черные гелевые ручки",
        Description = "Черные ручки закончились. Надо купить пачку-другую до начала проверочных.",
        BestBefore = new DateOnly(2015, 9, 20),
        Notabene = ""
    };

    static Note Note3 = new Note()
    {
        Date = new DateTime(2016, 02, 11, 9, 54, 23),
        Name = "Купить подарок",
        Description = "У Х скоро др. Нужно подобрать подарок хотя бы за неделю до самого др, чтобы потом не бегать.",
        BestBefore = new DateOnly(2016, 02, 22),
        Notabene = "Что-то по типу нового мерча Граф?? Длинная подушка-кот?? г о с п о ди"
    };
    static Note NoteF = new Note()
    {
        Date = new DateTime(2016, 02, 11, 10, 11, 34),
        Name = "Челлендж не запланируй ничего постороннего что нельзя отменить на день дра Х",
        Description = "We have failed at this challenge practically every year. CAn we just. Succeed?",
        BestBefore = new DateOnly(2016, 2, 22),
        Notabene = "Это не такой уж и тяжелый челлендж. я обязательно справлюсь"
    };
    static Note NoteG = new Note()
    {
        Date = new DateTime(2016, 02, 11, 12, 22, 44),
        Name = "Взять завтра зонт!!!",
        Description = "Обещают огромный ливень в течение всего дня",
        BestBefore = new DateOnly(2016, 2, 12),
        Notabene = "нет, не дождевик. зонт"
    };


    static Note Note4 = new Note()
    {
        Date = new DateTime(2016, 3, 10, 9, 01, 05),
        Name = "Забрать вечером посылку",
        Description = "Пришли стикеры. Надо забрать сегодня с почты",
        BestBefore = new DateOnly(2016, 3, 10),
        Notabene = "*happy noises* thry are finally here!!"
    };
    static Note Note5 = new Note()
    {
        Date = new DateTime(2016, 3, 21, 10, 30, 47),
        Name = "Покормить кота!!!",
        Description = "у него др и ему моське хочется мясного корма",
        BestBefore = new DateOnly(2015, 9, 16),
        Notabene = ""
    };

    public static List<Note> data1 = new List<Note>()
        {Note1, NoteA, NoteB};
    public static List<Note> data2 = new List<Note>()
        {Note2, NoteC};
    public static List<Note> data3 = new List<Note>()
        {Note3, NoteF, NoteG};
    public static List<Note> data4 = new List<Note>()
        {Note4};
    public static List<Note> data5 = new List<Note>()
        { Note5};
    public static List<List<Note>> full;

    static public int ArrrowUpDown(int k, int b1)
    {
        ConsoleKeyInfo key;
        int b = k;
        key = Console.ReadKey();

        do
        {
            Console.SetCursorPosition(0, b);
            Console.WriteLine(" ");

            if (key.Key == ConsoleKey.UpArrow && b != k)
            {
                b--;
            }
            if (key.Key == ConsoleKey.DownArrow && b != b1)
            {
                b++;
            }
            if (key.Key == ConsoleKey.Escape)
            {
                return -1;
            }

            Console.SetCursorPosition(0, b);
            Console.WriteLine(">");
            key = Console.ReadKey();

        } while (key.Key != ConsoleKey.Enter);

        return b;

    }

    static void ArrowLeftRight(int i)
    {

        int kcount = full.Count-1;

        ConsoleKeyInfo arrow ;

        do
        {
            arrow = Console.ReadKey();
            if (arrow.Key == ConsoleKey.LeftArrow && i != 0)
            {
                i--;
                Show(i);
            }
            else if (arrow.Key == ConsoleKey.RightArrow && i != kcount)
            {
                i++;
                Show(i);
            }
            else if (arrow.Key == ConsoleKey.RightArrow && i == kcount)
            {
                Show(0);
            }
            else if (arrow.Key == ConsoleKey.LeftArrow && i == 0)
            {
                Show(full.Count - 1);
            }
            else if (arrow.Key == ConsoleKey.Escape)
            {
                System.Environment.Exit(0);
            }
            else
            {
                return;
            }
        } while (arrow.Key != ConsoleKey.Enter);
    }

    static void Show(int a)
    {
        Console.Clear();
        Console.Write("Дата: " + full[a][0].Date.Date + "\n");
        foreach (Note pos in full[a])
        {
            Console.WriteLine(" " + pos.Name);

        }
    }

    static void Thenames(int a)
    {

        Show(a);
        ArrowLeftRight(a);
        int count = full[a].Count;
        int m = ArrrowUpDown(1, count);
        if (m == -1) { return; }
        m -= 1;
        if (m == 0)
        {
            Console.Clear();
            Console.WriteLine("Дата создания заметки: " + full[a][m].Date);
            Console.WriteLine("Название: " + full[a][m].Name);
            Console.WriteLine(full[a][m].Description);
            Console.WriteLine("Лучше сделать до: " + full[a][m].BestBefore);
            Console.WriteLine("ПЫсы: " + full[a][m].Notabene);
            ConsoleKeyInfo anotherkey = Console.ReadKey();
            if (anotherkey.Key == ConsoleKey.Tab)
            {
                Console.Clear();
                Thenames(a);
            }
            else
            {

            }

        }
        else
        {

        }
    }

    static void Main()
    {

        full = new List<List<Note>> { data1, data2, data3, data4, data5 };


        while (true)
        {
            Console.Clear();
        Console.WriteLine("Нажмите Esc для выхода из программы. \n Нажмите Tab для выхода в главное меню отдельной даты. \n Стрелки вверх-вниз передвигают Вас между позициями меню. Стрелки вправо-влево меняют даты. \n Ннажатие Enter откроет более подбробную информацию о выбранной позиции меню.");
        Console.WriteLine(" " + full[0][0].Date.Date);
        Console.WriteLine(" " + full[1][0].Date.Date);
        Console.WriteLine(" " + full[2][0].Date.Date);
        Console.WriteLine(" " + full[3][0].Date.Date);
        Console.WriteLine(" " + full[4][0].Date.Date);
        int pos = ArrrowUpDown(4, 8);
        if ( pos == 4)
        {
            Console.Clear();
            Thenames(0);
        }
        if (pos == 5)
        {
            Console.Clear();
            Thenames(1);
        }
        if (pos == 6)
        {
            Console.Clear();
            Thenames(2);
        }
        if (pos == 7)
        {
            Console.Clear();
            Thenames(3);
        }
        if (pos == 8)
        {
            Console.Clear();
            Thenames(4);
        }

        }
    }
}

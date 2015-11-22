using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Text.RegularExpressions;
using WCS.Models;
using WCS.Databases;

namespace WCS.Databases
{
    public class SetChangesInDb
    {
        NoteContext db = new NoteContext();
        public void SaveDb(Note note)
        {
            db.Notes.Add(note);
            db.SaveChanges();
        }
        public void SaveDb(State state)
        {
            db.States.Add(state);
            db.SaveChanges();
        }
        public void UpdateDb(Note note)
        {
            db.Entry(note).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void UpdateDb( State state )
        {
            db.Entry( state ).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteDb(Note note)
        {
            db.Notes.Remove( note );
            db.SaveChanges();
        }
        public void DeleteDb( State state )
        {
            db.States.Remove( state );
            db.SaveChanges();
        }
        public void DeleteDb()
        {
            db.Database.Delete();
            db.SaveChanges();
        }
        public void AddStatesToDb()
        {
            State[] states = new State[227];
            StringBuilder str = new StringBuilder("",100);
            string str1 = "asdsa";
            Regex newReg = new Regex(@">+[^<]+</");
            int i = 0;
            MatchCollection matches = newReg.Matches("<tbody><tr><td><a title=ВНЗ у регіоні: м. Київ href=/2015/i2015o27.html#reg>м. Київ</a></td></tr>				<tr><td><a title=ВНЗ у регіоні: Вінницька область href=/2015/i2015o3.html#reg>Вінницька область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Волинська область href=/2015/i2015o4.html#reg>Волинська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Дніпропетровська область href=/2015/i2015o5.html#reg>Дніпропетровська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Донецька область href=/2015/i2015o6.html#reg>Донецька область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Житомирська область href=/2015/i2015o7.html#reg>Житомирська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Закарпатська область href=/2015/i2015o8.html#reg>Закарпатська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Запорізька область href=/2015/i2015o9.html#reg>Запорізька область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Івано-Франківська область href=/2015/i2015o10.html#reg>Івано-Франківська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Київська область href=/2015/i2015o11.html#reg>Київська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Кіровоградська область href=/2015/i2015o12.html#reg>Кіровоградська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Луганська область href=/2015/i2015o13.html#reg>Луганська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Львівська область href=/2015/i2015o14.html#reg>Львівська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Миколаївська область href=/2015/i2015o15.html#reg>Миколаївська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Одеська область href=/2015/i2015o16.html#reg>Одеська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Полтавська область href=/2015/i2015o17.html#reg>Полтавська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Рівненська область href=/2015/i2015o18.html#reg>Рівненська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Сумська область href=/2015/i2015o19.html#reg>Сумська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Тернопільська область href=/2015/i2015o20.html#reg>Тернопільська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Харківська область href=/2015/i2015o21.html#reg>Харківська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Херсонська область href=/2015/i2015o22.html#reg>Херсонська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Хмельницька область href=/2015/i2015o23.html#reg>Хмельницька область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Черкаська область href=/2015/i2015o24.html#reg>Черкаська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Чернівецька область href=/2015/i2015o25.html#reg>Чернівецька область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: Чернігівська область href=/2015/i2015o26.html#reg>Чернігівська область</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: АР Крим href=/2015/i2015o2.html#reg>АР Крим</a></td></tr>		<tr><td><a title=ВНЗ у регіоні: м. Севастополь href=/2015/i2015o28.html#reg>м. Севастополь</a></td></tr>");
            foreach (Match mat in matches)
            {
                states[i] = new State();
                str.Append( mat.Value );
                str.Remove(0, 1);
                str.Replace( '/', ' ' );
                str.Replace( '<', ' ' );
                str1 = str.ToString();
                states[i].Name = str1;
                i++;
                states[i-1].StateID = i.ToString();
                str.Remove( 0, str.Length );
            }
            List<State> state = new List<State>(states);
            db.States.AddRange(state);
            db.SaveChanges();
        }
        public void AddUniversityToDb()
        {
            University[] univ = new University[42];
            StringBuilder str = new StringBuilder("",100);
            Regex newReg = new Regex(@">+[^<]+</a");
            int i = 0;
            int b = 0;
            MatchCollection matches = newReg.Matches("");
            foreach (Match mat in matches)
            {
                univ[i] = new University();
                univ[i].StateID = "28";
                str.Append( mat.Value );
                str.Remove( 0, 1 );
                b = str.Length;
                str.Remove( (b-3), 3);
                univ[i].Name = str.ToString();
                i++;
                univ[i - 1].UniversityID = (i + 1599).ToString();
                str.Remove( 0, str.Length );
            }
            List<University> univer = new List<University>(univ);
            db.Universities.AddRange( univer );
            db.SaveChanges();
        }
    }
}

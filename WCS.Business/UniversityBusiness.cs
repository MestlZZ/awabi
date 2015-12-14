﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Text.RegularExpressions;
using WCS.Models;
using WCS.Databases;
using WCS.Business;

namespace WCS.Business
{
    public static class UniversityBusiness
    {
        public static University Get(string id)
        {
            Universiteties db = new Universiteties();
            return db.Get(id);
        }

        public static string GetName(string id)
        {
            var univers = Get(id);
            if (univers == null)
                return null;
            else
                return univers.Name;
        }

        public static IList<University> GetList()
        {
            Universiteties db = new Universiteties();
            return db.GetList();
        }

        public static int GetLastId()
        {
            var univers = GetList();
            return univers.Count;
        }

        private static void AddToDb()
        {
            System.Collections.Generic.List<University> univ = new System.Collections.Generic.List<University>();
            StringBuilder str = new StringBuilder("", 100);
            int lastID = GetLastId();
            University buf = Get(lastID.ToString());
            Regex newReg = new Regex(@">+[^<]+</a");
            int i = 0;
            int b = 0;
            string sId = (Convert.ToInt32(buf.StateID) + 1).ToString();
            MatchCollection matches = newReg.Matches("");
            foreach (Match mat in matches)
            {
                buf.StateID = sId;
                str.Append(mat.Value);
                str.Remove(0, 1);
                b = str.Length;
                str.Remove((b - 3), 3);
                buf.Name = str.ToString();
                i++;
                buf.UniversityID = (i + lastID).ToString();
                str.Remove(0, str.Length);
                univ.Add(buf);
                buf = new University();
            }
            List<University> univer = new List<University>(univ);
            Universiteties db = new Universiteties();
            db.AddList(univer);
        }

        public static UniversityInfo GetInfo( string univers, bool contract, bool award, int choose )
        {
            UniversityInfo un = new UniversityInfo();

            var notes = NotesBusiness.GetListFromUniversity( univers );

            un.Award = 820;
            un.StateName = StateBusiness.GetStateNameFromUniversity( univers );
            un.UniversityName = GetName( univers );
            un.UniversityID = univers;
            un.IsContract = contract;
            un.Choose = choose;
            un.IsHaveAward = award;

            int ef = 0, et = 0, ra = 0, rd = 0;

            un.MinimalTaitionFee = double.MaxValue;

            foreach (var note in notes)
            {
                if (note.ExpensesFood > 0)
                {
                    un.ExpensesFood += note.ExpensesFood;
                    ef++;
                }

                if (note.ExpensesTravel > 0)
                {
                    un.ExpensesTravel += note.ExpensesTravel;
                    et++;
                }

                if (note.RentsApartment > 0 && choose == 2)
                {
                    un.RentsApartment += note.RentsApartment;
                    ra++;
                }

                if (note.RentsDormitory > 0 && choose == 3)
                {
                    un.RentsDormitory += note.RentsDormitory;
                    rd++;
                }

                if (contract)
                {
                    if (un.MaximalTaitionFee < note.MaximalTaitionFee)
                        un.MaximalTaitionFee = note.MaximalTaitionFee;

                    if (un.MinimalTaitionFee > note.MinimalTaitionFee)
                        un.MinimalTaitionFee = note.MinimalTaitionFee;
                }
            }

            if (!contract)
                un.MinimalTaitionFee = 0;

            if (ef > 0)
                un.ExpensesFood /= (double)ef;
            if (et > 0)
                un.ExpensesTravel /= (double)et;
            if (ra > 0 && choose == 2)
                un.RentsApartment /= (double)ra;
            if (rd > 0 && choose == 3)
                un.RentsDormitory /= (double)rd;

            un.MaximalResult = un.MinimalResult = un.RentsDormitory + un.RentsApartment + un.ExpensesTravel + un.ExpensesFood;

            if (contract)
            {
                un.MinimalResult += un.MinimalTaitionFee;
                un.MaximalResult += un.MaximalTaitionFee;
            }

            if (award)
            {
                un.MaximalResult -= un.Award;
                un.MinimalResult -= un.Award;
            }

            RoundInfo( un );

            if (Double.IsNaN( un.MaximalResult ) || Double.IsNaN( un.MinimalResult ))
                un.IsNaN = true;

            return un;
        }
        public static UniversityInfo GetInfo( string univers )
        {
            UniversityInfo un = new UniversityInfo();

            var notes = NotesBusiness.GetListFromUniversity( univers );

            un.Award = 820;
            un.StateName = StateBusiness.GetStateNameFromUniversity( univers );
            un.UniversityName = GetName( univers );
            un.UniversityID = univers;

            int ef = 0, et = 0, ra = 0, rd = 0;

            un.MinimalTaitionFee = double.MaxValue;

            foreach(var note in notes)
            {
                if (note.ExpensesFood > 0)
                {
                    un.ExpensesFood += note.ExpensesFood;
                    ef++;
                }

                if (note.ExpensesTravel > 0)
                {
                    un.ExpensesTravel += note.ExpensesTravel;
                    et++;
                }

                if (note.RentsApartment > 0)
                {
                    un.RentsApartment += note.RentsApartment;
                    ra++;
                }

                if (note.RentsDormitory > 0)
                {
                    un.RentsDormitory += note.RentsDormitory;
                    rd++;
                }

                if (un.MaximalTaitionFee < note.MaximalTaitionFee)
                    un.MaximalTaitionFee = note.MaximalTaitionFee;

                if (un.MinimalTaitionFee > note.MinimalTaitionFee)
                    un.MinimalTaitionFee = note.MinimalTaitionFee;
            }

            if (ef > 0)
                un.ExpensesFood /= (double)ef;
            if (et > 0)
                un.ExpensesTravel /= (double)et;
            if (ra > 0)
                un.RentsApartment /= (double)ra;
            if (rd > 0)
                un.RentsDormitory /= (double)rd;

            un.MinimalResult = un.MaximalResult = un.RentsDormitory + un.RentsApartment + un.ExpensesTravel + un.ExpensesFood - un.Award;
            un.MinimalResult += un.MinimalTaitionFee;
            un.MaximalResult += un.MaximalTaitionFee;

            RoundInfo( un );

            if (Double.IsNaN( un.MaximalResult ) || Double.IsNaN( un.MinimalResult ))
                un.IsNaN = true;

            return un;
        }

        public static void RoundInfo( UniversityInfo un )
        {
            un.MaximalTaitionFee = Math.Round( un.MaximalTaitionFee, 2 );
            un.MaximalResult = Math.Round( un.MaximalResult, 2 );
            un.MinimalTaitionFee = Math.Round( un.MinimalTaitionFee, 2 );
            un.MinimalResult = Math.Round( un.MinimalResult, 2 );
            un.RentsApartment = Math.Round( un.RentsApartment, 2 );
            un.RentsDormitory = Math.Round( un.RentsDormitory, 2 );
            un.ExpensesFood = Math.Round( un.ExpensesFood, 2 );
            un.ExpensesTravel = Math.Round( un.ExpensesTravel, 2 );
        }

        public static IList<University> GetListWithNotes()
        {
            var notes = NotesBusiness.GetList();
            System.Collections.Generic.List<University> university = new System.Collections.Generic.List<University>();
            int[] arr = new int[2000];
            foreach(var note in notes)
            {
                if (arr[Convert.ToInt32( note.UniversityID )] != 0)
                    continue;
                else
                    arr[Convert.ToInt32( note.UniversityID )]++;
                university.Add( Get( note.UniversityID ) );
            }
            return university;
        }
        public static IList<University> GetListWithNotes( out int[] arr )
        {
            var notes = NotesBusiness.GetList();
            System.Collections.Generic.List<University> university = new System.Collections.Generic.List<University>();
            arr = new int[2000];
            foreach (var note in notes)
            {
                if (arr[Convert.ToInt32( note.UniversityID )]++ != 0)
                    continue;
                else
                    arr[Convert.ToInt32( note.UniversityID )]++;
                university.Add( Get( note.UniversityID ) );
            }
            return university;
        }

        public static IList<UniversityInfo> GetListUniversityInfo()
        {
            var univers = GetListWithNotes();
            System.Collections.Generic.List<UniversityInfo> universityInfo = new System.Collections.Generic.List<UniversityInfo>();
            UniversityInfo unInfo;
            foreach(var univer in univers)
            {
                var notes = NotesBusiness.GetListFromUniversity( univer.UniversityID );
                if (notes.Count < 1)
                    continue;
                unInfo = GetInfo( univer.UniversityID );
                if (unInfo.IsNaN || 
                    Double.IsNaN(unInfo.MaximalTaitionFee) ||
                    Double.IsNaN( unInfo.MinimalTaitionFee ) ||
                    Double.IsNaN( unInfo.ExpensesTravel ) ||
                    Double.IsNaN( unInfo.ExpensesFood )  ||
                    Double.IsNaN( unInfo.RentsApartment ))
                    continue;
                universityInfo.Add( unInfo );
            }
            return universityInfo;
        }

        public static IList<UniversityInfo> GetListUniversityInfo( string UniversityID )
        {
            var notes = NotesBusiness.GetList();
            System.Collections.Generic.List<UniversityInfo> univers = new System.Collections.Generic.List<UniversityInfo>();

            int[] arr = new int[2000];
            for (int j = 0; j < notes.Count; j++)
            {
                if (arr[Convert.ToInt32( notes[j].UniversityID )] != 0)
                    continue;
                else
                    arr[Convert.ToInt32( notes[j].UniversityID )]++;

                var unInfo = GetInfo( notes[j].UniversityID );

                if (UniversityID != unInfo.UniversityID || unInfo.IsNaN ||
                    Double.IsNaN( unInfo.MaximalTaitionFee ) ||
                    Double.IsNaN( unInfo.MinimalTaitionFee ) ||
                    Double.IsNaN( unInfo.ExpensesTravel ) ||
                    Double.IsNaN( unInfo.ExpensesFood ) ||
                    Double.IsNaN( unInfo.RentsApartment ))
                {
                    continue;
                }
                univers.Add( unInfo );
            }

            return univers;
        }

        public static IList<UniversityInfo> GetListFiveUniversityInfo( int page = 0 )
        {
            var notes = NotesBusiness.GetList();
            System.Collections.Generic.List<UniversityInfo> univers = new System.Collections.Generic.List<UniversityInfo>();

            int length = notes.Count - page * 5;
            if (length >= 5)
                length = 5;
            else
                length %= 5;

            int[] arr = new int[2000];
            for(int j = page * 5; j < page * 5 + length; j++)
            {
                if (arr[Convert.ToInt32( notes[j].UniversityID )] != 0)
                    continue;
                else
                    arr[Convert.ToInt32( notes[j].UniversityID )]++;

                var unInfo = GetInfo( notes[j].UniversityID );

                if (unInfo.IsNaN ||
                    Double.IsNaN( unInfo.MaximalTaitionFee ) ||
                    Double.IsNaN( unInfo.MinimalTaitionFee ) ||
                    Double.IsNaN( unInfo.ExpensesTravel ) ||
                    Double.IsNaN( unInfo.ExpensesFood ) ||
                    Double.IsNaN( unInfo.RentsApartment ))
                {
                    if (length > 4 && length + 1 + page * 5 < notes.Count)
                        length++;
                    continue;
                }
                univers.Add( unInfo );
            }
           
            return univers;
        }
    }
}
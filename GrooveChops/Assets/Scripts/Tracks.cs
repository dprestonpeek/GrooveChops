using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracks : MonoBehaviour
{
    public struct Drums
    {
        public static bool IsNote(int midiNote, int[] drumMap)
        {
            if (drumMap == null)
            {
                return false;
            }
            foreach (int num in drumMap)
            {
                if (num == midiNote)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public struct DrumMap
    {
        public static int[][] Map = new int[12][] { DefaultKick, DefaultSnare, DefaultTom0, DefaultTom1, DefaultTom2, DefaultTom3,
            DefaultLeftCrash, DefaultRightCrash, DefaultHihat, DefaultRide, DefaultChina, DefaultSplash };

        public static int[] Kick { get { return Map[0]; } set { Kick = value; } }
        public static int[] Snare { get { return Map[1]; } set { Snare = value; } }
        public static int[] Tom0 { get { return Map[2]; } set { Tom0 = value; } }
        public static int[] Tom1 { get { return Map[3]; } set { Tom1 = value; } }
        public static int[] Tom2 { get { return Map[4]; } set { Tom2 = value; } }
        public static int[] Tom3 { get { return Map[5]; } set { Tom3 = value; } }
        public static int[] LeftCrash { get { return Map[6]; } set { LeftCrash = value; } }
        public static int[] RightCrash { get { return Map[7]; } set { RightCrash = value; } }
        public static int[] Hihat { get { return Map[8]; } set { Hihat = value; } }
        public static int[] Ride { get { return Map[9]; } set { Ride = value; } }
        public static int[] China { get { return Map[10]; } set { China = value; } }
        public static int[] Splash { get { return Map[11]; } set { Splash = value; } }

        public static int[][] DefaultMap = new int[12][] { DefaultKick, DefaultSnare, DefaultTom0, DefaultTom1, DefaultTom2, DefaultTom3,
            DefaultLeftCrash, DefaultRightCrash, DefaultHihat, DefaultRide, DefaultChina, DefaultSplash };
        public static int[] DefaultKick = new int[] { 35, 36 };                 //kick, alt kick
        public static int[] DefaultSnare = new int[] { 33, 37, 38, 40, 91 };    //sidestick x2, snare, esnare, rimshot
        public static int[] DefaultTom0 = new int[] { 48, 50 };                 //high tom, higher tom
        public static int[] DefaultTom1 = new int[] { 47, 60 };                 //lo mid, high bongo
        public static int[] DefaultTom2 = new int[] { 45, 61 };                 //mid tom, low bongo
        public static int[] DefaultTom3 = new int[] { 41, 43 };                 //low floor tom, floor tom
        public static int[] DefaultLeftCrash = new int[] { 57, 98 };            //left crash, choked left crash
        public static int[] DefaultRightCrash = new int[] { 49, 97 };           //right crash, choked right crash
        public static int[] DefaultHihat = new int[] { 42, 44, 46, 92 };        //hh closed, hh pedal, hh open, hh half open
        public static int[] DefaultRide = new int[] { 51, 53, 59, 93, 94 };     //ride tip, ride bell, ride 2, ride crash, choked ride crash
        public static int[] DefaultChina = new int[] { 52, 96 };                //china, choked china
        public static int[] DefaultSplash = new int[] { 55, 95 };               //splash, choked splash
    }
}

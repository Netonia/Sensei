using Sensei.Models;

namespace Sensei.Data;

public static class Week
{
    public static readonly List<WeekDay> Days = new List<WeekDay>()
    {
         new WeekDay("Sunday", "日曜日", "nichiyōbi", "Sun"),
         new WeekDay("Monday", "月曜日", "getsuyōbi", "Moon"),
         new WeekDay("Tuesday", "火曜日", "kayōbi", "Fire (Mars)"),
         new WeekDay("Wednesday", "水曜日", "suiyōbi", "Water (Mercury)"),
         new WeekDay("Thursday", "木曜日", "mokuyōbi", "Wood (Jupiter)"),
         new WeekDay("Friday", "金曜日", "kin'yōbi", "Metal (Venus)"),
         new WeekDay("Saturday", "土曜日", "doyōbi", "Earth (Saturn)")
    };
}
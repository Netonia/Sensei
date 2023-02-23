using Sensei.Models;

namespace Sensei.Data;

public static class Sentences
{
    public static List<Sentence> All()
    {
        return YesNo.Union(Politeness).Union(Greetings).Union(Introduction).Union(Farewell).Union(Questions).ToList();
    }

    public static readonly List<Sentence> YesNo = new List<Sentence>()
    {
         new Sentence(nameof(YesNo), "yes", "はい"),
         new Sentence(nameof(YesNo), "no", "いいえ")
    };

    public static readonly List<Sentence> Politeness = new List<Sentence>()
    {
         new Sentence(nameof(Politeness), "Please", "ください"),
         new Sentence(nameof(Politeness), "Please", "お願いします"),
         new Sentence(nameof(Politeness), "Excuse me", "すみません"),
         new Sentence(nameof(Politeness), "Sorry", "ごめん なさい"),
         new Sentence(nameof(Politeness), "Happy to meet you", "はじめまして"),
         new Sentence(nameof(Politeness), "How are you?", "元気ですか？"),
         new Sentence(nameof(Politeness), "Welcome", "いらっしゃいませ")
    };

    public static readonly List<Sentence> Greetings = new List<Sentence>()
    {
         new Sentence(nameof(Greetings), "Good morning", "おはようございます"),
         new Sentence(nameof(Greetings), "Good afternoon", "こんにちは"),
         new Sentence(nameof(Greetings), "Good evening", "こんばんは")
    };

    public static readonly List<Sentence> Farewell = new List<Sentence>()
    {
         new Sentence(nameof(Farewell), "Have a nice day", "よい一日を")
    };

    public static readonly List<Sentence> Introduction = new List<Sentence>()
    {
         new Sentence(nameof(Introduction), "What's your name?", "お名前は何ですか"),
         new Sentence(nameof(Introduction), "Happy to meet you", "はじめまして"),
         new Sentence(nameof(Introduction), "Nice to meet you", "どうぞよろしく")
    };

    public static readonly List<Sentence> Questions = new List<Sentence>()
    {
         new Sentence(nameof(Questions), "What?", "何"),
         new Sentence(nameof(Questions), "Where?", "どこ"),
         new Sentence(nameof(Questions), "Who?", "誰"),
         new Sentence(nameof(Questions), "When?", "いつ"),
         new Sentence(nameof(Questions), "Why?", "なぜ"),
         new Sentence(nameof(Questions), "Because", "から")
    };
}
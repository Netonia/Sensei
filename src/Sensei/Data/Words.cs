using Sensei.Models;

namespace Sensei.Data;

public static class Words
{
    public static List<Word> All()
    {
        return Common.
                Union(Animals).
                Union(Colors).
                Union(Days).
                Union(Months)
                .ToList();
    }

    public static readonly List<Word> Animals = new()
    {
         new Word(nameof(Animals), "chat", "猫"),
         new Word(nameof(Animals), "chien", "犬"),
         new Word(nameof(Animals), "souris", "メズミ"),
         new Word(nameof(Animals), "cheval", "馬"),
         new Word(nameof(Animals), "alligator", "ワニ"),
         new Word(nameof(Animals), "lapin", "ウサギ"),
         new Word(nameof(Animals), "oiseau", "鳥"),
         new Word(nameof(Animals), "ours", "熊"),
         new Word(nameof(Animals), "aigle", "ワシ"),
         new Word(nameof(Animals), "éléphant", "象"),
         new Word(nameof(Animals), "girafe", "キリン"),
         new Word(nameof(Animals), "lion", "ライオン"),
         new Word(nameof(Animals), "singe", "猿"),
         new Word(nameof(Animals), "serpent", "ヘビ"),
         new Word(nameof(Animals), "tigre", "虎")
    };

    public static readonly List<Word> Colors = new()
    {
         new Word(nameof(Colors), "couleur", "色"),
         new Word(nameof(Colors), "noir", "黒"),
         new Word(nameof(Colors), "blanc", "白"),
         new Word(nameof(Colors), "gris", "灰"),
         new Word(nameof(Colors), "rouge", "赤"),
         new Word(nameof(Colors), "bleu", "青"),
         new Word(nameof(Colors), "jaune", "黄"),
         new Word(nameof(Colors), "vert", "緑"),
         new Word(nameof(Colors), "orange", "橙"),
         new Word(nameof(Colors), "violet", "紫"),
         new Word(nameof(Colors), "marron", "茶")
    };

    // Cours de japonais : 100 mots courants
    public static readonly List<Word> Common = new()
    {
        new Word(nameof(Common), "aller", "行きます"), // ikimasu = aller
        new Word(nameof(Common), "avoir", "あります"), // arimasu = avoir
        new Word(nameof(Common), "aimer", "好きです"), // suki desu = aimer
        new Word(nameof(Common), "ami", "ともだち"), // tomodachi = ami
        new Word(nameof(Common), "après ça", "それから"), // sorekara = après ça
        new Word(nameof(Common), "à plus tard", "またね"), // mata ne = à plus tard
        new Word(nameof(Common), "autre", "他"), // hoka, betsu = autre
        new Word(nameof(Common), "avant", "前"), // mae = avant
        new Word(nameof(Common), "bien", "いい"), // ii = bien
        new Word(nameof(Common), "beaucoup", "たくさん"), // takusan, totemo = beaucoup
        new Word(nameof(Common), "bon", "美味しい"), // oishii = bon
        new Word(nameof(Common), "bonjour", "こんにちは"), // kon'nichiwa = bonjour
        new Word(nameof(Common), "bonsoir", "今晩は"), // konbanwa = bonsoir
        new Word(nameof(Common), "ceci", "これ"), // kore = ceci
        new Word(nameof(Common), "cela", "それ"), // sore = cela
        new Word(nameof(Common), "chose", "もの"), // mono = chose
        new Word(nameof(Common), "comprendre", "わかります"), // wakarimasu = comprendre
        new Word(nameof(Common), "comment", "ど"), // dô, dôyatte = comment
        new Word(nameof(Common), "content", "嬉しい"), // ureshii = content
        new Word(nameof(Common), "pendant", "中"), // naka = pendant
        new Word(nameof(Common), "dehors", "外"), // soto = dehors
        new Word(nameof(Common), "déjà", "もう"), // mô = déjà
        new Word(nameof(Common), "dernier", "さいご"), // saigo = dernier
        new Word(nameof(Common), "devenir", "なる"), // naru = devenir
        new Word(nameof(Common), "dire", "いいます"), // iimasu = dire
        new Word(nameof(Common), "donc", "だから"), // dakara = donc
        new Word(nameof(Common), "écouter", "聞く"), // kikimasu = écouter
        new Word(nameof(Common), "elle", "彼女"), // kanojo = elle
        new Word(nameof(Common), "au-dessus", "うえ"), // ue = au-dessus
        new Word(nameof(Common), "encore une fois", "もう一度"), // mōichido = encore une fois
        new Word(nameof(Common), "à nouveau", "また"), // mata = à nouveau
        new Word(nameof(Common), "enfant", "子供"), // kodomo = enfant
        new Word(nameof(Common), "ensemble", "一緒"), // issho ni = ensemble
        new Word(nameof(Common), "et puis", "そして"), // soshite = et puis
        new Word(nameof(Common), "être", "です"), // desu = être
        new Word(nameof(Common), "faire", "します"), // shimasu = faire
        new Word(nameof(Common), "grand", "大きい"), // ookii = grand
        new Word(nameof(Common), "personne", "人"), // hito = personne
        new Word(nameof(Common), "heure", "時"), // ji = heure
        new Word(nameof(Common), "ici", "ここ"), // koko = ici
        new Word(nameof(Common), "il", "彼"), // kare = il, lui
        new Word(nameof(Common), "je", "私"), // watashi = je, moi
        new Word(nameof(Common), "là-bas", "あそこ"), // asoko = là-bas
        new Word(nameof(Common), "lequel", "どちら"), // dochira = lequel
        new Word(nameof(Common), "lequel", "どれ"), // dore = lequel
        new Word(nameof(Common), "maintenant", "今"), // ima = maintenant
        new Word(nameof(Common), "mais", "でも"), // demo = mais
        new Word(nameof(Common), "maison", "家"), // ie, uchi = maison
        new Word(nameof(Common), "même", "同じ"), // onaji = même
        new Word(nameof(Common), "merci", "ありがとうございました"), // arigatōgozaimashita = merci
        new Word(nameof(Common), "mon", "私 の"), // watashi no = mon
        new Word(nameof(Common), "mot", "言葉"), // kotoba = mot
        new Word(nameof(Common), "ne pas être", "ジャ ありません"), // ja arimasen = ne pas être
        new Word(nameof(Common), "non", "いいえ"), // iie = non
        new Word(nameof(Common), "nous", "私達"), // watashitachi = nous
        new Word(nameof(Common), "nouveau", "新しい"), // atarashii = nouveau
        new Word(nameof(Common), "oui", "はい"), // hai = oui
        new Word(nameof(Common), "où", "どこ"), // doko = où
        new Word(nameof(Common), "parfois", "時々"), // tokidoki = parfois
        new Word(nameof(Common), "penser", "思います"), // omoimasu = penser
        new Word(nameof(Common), "petit", "小さい"), // chiisai = petit
        new Word(nameof(Common), "peut-être", "多分"), // tabbn = peut-être
        new Word(nameof(Common), "pouvoir", "できます"), // dekimasu = pouvoir
        new Word(nameof(Common), "lieu", "場所"), // tokoro, basho = lieu
        new Word(nameof(Common), "la plupart", "ほとんど"), // hotondo = la plupart, en grande partie
        new Word(nameof(Common), "plus", "もっと"), // motto = plus
        new Word(nameof(Common), "pourquoi", "どうして"), // doshite = pourquoi
        new Word(nameof(Common), "premier", "ichiban"), // ichiban = premier
        new Word(nameof(Common), "quand", "いつ"), // itsu = quand
        new Word(nameof(Common), "quelque chose", "なにか"), // nanika = quelque chose
        new Word(nameof(Common), "quelque part", "どこか"), // dokoka = quelque part
        new Word(nameof(Common), "quelqu'un", "誰か"), // dareka = quelqu'un
        new Word(nameof(Common), "qui", "誰"), // dare = qui
        new Word(nameof(Common), "quoi", "何"), // nani = quoi
        new Word(nameof(Common), "regarder", "見る"), // miru = regarder
        new Word(nameof(Common), "s'il vous plaît", "お願いします"), // onegai shimasu = s'il vous plaît
        new Word(nameof(Common), "savoir", "知っています"), // shitteimasu = savoir
        new Word(nameof(Common), "seulement", "だけ"), // dake = seulement
        new Word(nameof(Common), "si", "もし"), // moshi = si
        new Word(nameof(Common), "sortir", "でます"), // demasu = sortir
        new Word(nameof(Common), "souvent", "よく"), // yoku = souvent
        new Word(nameof(Common), "sous", "下"), // shita = sous
        new Word(nameof(Common), "téléphone", "電話"), // denwa = téléphone
        new Word(nameof(Common), "temps", "時間"), // jikan = temps
        new Word(nameof(Common), "ton", "あなたの"), // anata no = ton
        new Word(nameof(Common), "à chaque fois", "いつも"), // itsumo = toujours, à chaque fois
        new Word(nameof(Common), "tout", "全部"), // zenbu = tout
        new Word(nameof(Common), "tout le monde", "みんな"), // min'na = tout le monde
        new Word(nameof(Common), "travail", "仕事"), // shigoto = travail
        new Word(nameof(Common), "trouver", "見つけます"), // mitsukemasu = trouver
        new Word(nameof(Common), "tu", "あなた"), // anata = tu
        new Word(nameof(Common), "un", "一つ"), // hitotsu = un
        new Word(nameof(Common), "un peu", "少し"), // sukoshi, chotto = un peu
        new Word(nameof(Common), "utiliser", "使います"), // tsukaimasu = utiliser
        new Word(nameof(Common), "venir", "来ます"), // kimasu = venir
    };

    public static readonly List<Word> Days = new()
    {
         new Word(nameof(Days), "Dimanche", "日曜日"),
         new Word(nameof(Days), "Lundi", "月曜日"),
         new Word(nameof(Days), "Mardi", "火曜日"),
         new Word(nameof(Days), "Mercredi", "水曜日"),
         new Word(nameof(Days), "Jeudi", "木曜日"),
         new Word(nameof(Days), "Vendredi", "金曜日"),
         new Word(nameof(Days), "Samedi", "土曜日")
    };

    public static readonly List<Word> Months = new()
    {
         new Word(nameof(Months), "Janvier", "一月"),
         new Word(nameof(Months), "Février", "二月"),
         new Word(nameof(Months), "Mars", "三月"),
         new Word(nameof(Months), "Avril", "四月"),
         new Word(nameof(Months), "Mai", "五月"),
         new Word(nameof(Months), "Juin", "六月"),
         new Word(nameof(Months), "Juillet", "七月"),
         new Word(nameof(Months), "Août", "八月"),
         new Word(nameof(Months), "Septembre", "九月"),
         new Word(nameof(Months), "Octobre", "十月"),
         new Word(nameof(Months), "Novembre", "十一月"),
         new Word(nameof(Months), "Décembre", "十二月")
    };
}
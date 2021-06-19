using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Generator.MonoGame.Utility
{
    enum GlyphNames
    {
        NullCharacter,
        /// <summary>☺</summary>
        OpenSmiley,
        /// <summary>☻</summary>
        ClosedSmiley,
        /// <summary>♥</summary>
        Heart,
        /// <summary>♦</summary>
        Diamond,
        /// <summary>♣</summary>
        Club,
        /// <summary>♠</summary>
        Spade,
        /// <summary>•</summary>
        Bullet,
        /// <summary>◘</summary>
        InverseBullet,
        /// <summary>◦</summary>
        Circle,
        /// <summary></summary>
        InverseCircle,
        /// <summary>♂</summary>
        MaleSymbol,
        /// <summary>♀</summary>
        FemaleSymbol,
        /// <summary>♪</summary>
        EighthNote,
        /// <summary>♫</summary>
        BeamedEighthNotes,
        /// <summary>✶</summary>
        SixPointStar,
        /// <summary>⏵</summary>
        TriangleRight,
        /// <summary>⏴</summary>
        TriangleLeft,
        /// <summary>↕</summary>
        UpDownArrow,
        /// <summary>‼</summary>
        DoubleExclamationPoint,
        /// <summary>¶</summary>
        PilcrowSign,
        /// <summary>§</summary>
        SectionSign,
        /// <summary>▃</summary>
        LowerThreeEighthsBlock,
        /// <summary>↨</summary>
        UpDownArrowWithBase,
        /// <summary>↑</summary>
        UpArrow,
        /// <summary>↓</summary>
        DownArrow,
        /// <summary>→</summary>
        RightArrow,
        /// <summary>←</summary>
        LeftArrow,
        /// <summary></summary>
        TurnedReversedNot,
        /// <summary>↔</summary>
        LeftRightArrow,
        /// <summary>⏶</summary>
        TriangleUp,
        /// <summary>⏷</summary>
        TriangleDown,
        Space,
        /// <summary>!</summary>
        ExclamationPoint,
        /// <summary>"</summary>
        DoubleQuote,
        /// <summary>#</summary>
        Octothorpe,
        /// <summary>$</summary>
        DollarSign,
        /// <summary>%</summary>
        PercentSymbol,
        /// <summary>&amp;</summary>
        Ampersand,
        /// <summary>'</summary>/summary>
        Apostrophe,
        /// <summary>(</summary>
        OpenParenthesis,
        /// <summary>)</summary>
        CloseParenthesis,
        /// <summary>*</summary>
        Asterisk,
        /// <summary>+</summary>
        PlusSign,
        /// <summary>,</summary>
        Comma,
        /// <summary>-</summary>
        Hyphen,
        /// <summary>.</summary>
        Period,
        /// <summary>/</summary>
        Slash,
        /// <summary>0</summary>
        Zero,
        /// <summary>1</summary>
        One,
        /// <summary>2</summary>
        Two,
        /// <summary>3</summary>
        Three,
        /// <summary>4</summary>
        Four,
        /// <summary>5</summary>
        Five,
        /// <summary>6</summary>
        Six,
        /// <summary>7</summary>
        Seven,
        /// <summary>8</summary>
        Eight,
        /// <summary>9</summary>
        Nine,
        /// <summary>:</summary>
        Colon,
        /// <summary>;</summary>
        SemiColon,
        /// <summary>&lt;</summary>
        LessThan,
        /// <summary>=</summary>
        EqualSign,
        /// <summary>&gt;</summary>
        GreaterThan,
        /// <summary>?</summary>
        QuestionMark,
        /// <summary>@</summary>
        CommercialAt,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        /// <summary>[</summary>
        OpenSquareBrace,
        /// <summary>\</summary>
        BackSlash,
        /// <summary>]</summary>
        CloseSquareBrace,
        /// <summary>^</summary>
        Caret,
        /// <summary>_</summary>
        Underscore,
        /// <summary>`</summary>
        Backtick,
        a,
        b,
        c,
        d,
        e,
        f,
        g,
        h,
        i,
        j,
        k,
        l,
        m,
        n,
        o,
        p,
        q,
        r,
        s,
        t,
        u,
        v,
        w,
        x,
        y,
        z,
        /// <summary>{</summary>
        OpenCurlyBrace,
        /// <summary>¦</summary>
        VerticalBrokenBar,
        /// <summary>}</summary>
        CloseCurlyBrace,
        /// <summary>~</summary>
        Tilde,
        /// <summary>⌂</summary>
        House,
        /// <summary>Ç</summary>
        CCedilla,
        /// <summary>ü</summary>
        uUmlaut,
        /// <summary>é</summary>
        eAcute,
        /// <summary>â</summary>
        aCircumflex,
        /// <summary>ä</summary>
        aUmlaut,
        /// <summary>à</summary>
        aGrave,
        /// <summary>å</summary>
        aRing,
        /// <summary>ç</summary>
        cCedilla,
        /// <summary>ê</summary>
        eCircumflex,
        /// <summary>ë</summary>
        eUmlaut,
        /// <summary>è</summary>
        eGrave,
        /// <summary>ï</summary>
        iUmlaut,
        /// <summary>î</summary>
        iCircumflex,
        /// <summary>ì</summary>
        iGrave,
        /// <summary>Ä</summary>
        AUmlaut,
        /// <summary>Å</summary>
        ARing,
        /// <summary>É</summary>
        EAcute,
        /// <summary>%</summary>
        PercentSign,
        /// <summary>Æ</summary>
        Ashe,
        /// <summary>ô</summary>
        oCircumflex,
        /// <summary>ö</summary>
        oUmlaut,
        /// <summary>ò</summary>
        oGrave,
        /// <summary>û</summary>
        uCircumflex,
        /// <summary>ù</summary>
        uGrave,
        /// <summary>ÿ</summary>
        yUmlaut,
        /// <summary>Ö</summary>
        OUmlaut,
        /// <summary>Ü</summary>
        UUmlaut,
        /// <summary>¢</summary>
        CentSign,
        /// <summary>£</summary>
        PoundSign,
        /// <summary>¥</summary>
        YenSign,
        /// <summary>₽</summary>
        Ruble,
        /// <summary>⨍</summary>
        FinitePartIntegral,
        /// <summary>á</summary>
        aAcute,
        /// <summary>í</summary>
        iAcute,
        /// <summary>ó</summary>
        oAcute,
        /// <summary>ú</summary>
        uAcute,
        /// <summary>ñ</summary>
        nTilde,
        /// <summary>Ñ</summary>
        NTilde,
        /// <summary>ª</summary>
        FeminineOrdinal,
        /// <summary>º</summary>
        MasculineOrdinal,
        /// <summary>¿</summary>
        InvertedQuestionMark,
        /// <summary>⌐</summary>
        ReversedNot,
        /// <summary>¬</summary>
        Not,
        /// <summary>½</summary>
        Half,
        /// <summary>¼</summary>
        Quarter,
        /// <summary>¡</summary>
        InvertedExclamationPoint,
        /// <summary>«</summary>
        LeftDoubleAngleQuotationMarks,
        /// <summary>»</summary>
        RightDoubleAngleQuotationMarks,
        /// <summary>░</summary>
        LightShade,
        /// <summary>▒</summary>
        MediumShade,
        /// <summary>▓</summary>
        DarkShade,
        /// <summary>│</summary>
        BoxVertical,
        /// <summary>┤</summary>
        BoxVerticalAndLeft,
        /// <summary>╡</summary>
        BoxVerticalSingleAndLeftDouble,
        /// <summary>╢</summary>
        BoxVerticalDoubleAndLeftSingle,
        /// <summary>╖</summary>
        BoxDownDoubleAndLeftSingle,
        /// <summary>╕</summary>
        BoxDownSingleAndLeftDouble,
        /// <summary>╣</summary>
        BoxDoubleVerticalAndLeft,
        /// <summary>║</summary>
        BoxDoubleVertical,
        /// <summary>╗</summary>
        BoxDownDoubleAndLeft,
        /// <summary>╝</summary>
        BoxUpDoubleAndLeft,
        /// <summary>╜</summary>
        BoxUpDoubleAndLeftSingle,
        /// <summary>╛</summary>
        BoxUpSingleAndLeftDouble,
        /// <summary>┐</summary>
        BoxDownAndLeft,
        /// <summary>└</summary>
        BoxDownAndRight,
        /// <summary>┴</summary>
        BoxUpAndHorizontal,
        /// <summary>┬</summary>
        BoxDownAndHorizontal,
        /// <summary>├</summary>
        BoxVerticalAndRight,
        /// <summary>─</summary>
        BoxHorizontal,
        /// <summary>┼</summary>
        BoxVerticalAndHorizontal,
        /// <summary>╞</summary>
        BoxVerticalSingleAndRightDouble,
        /// <summary>╟</summary>
        BoxVerticalDoubleAndRightSingle,
        /// <summary>╚</summary>
        BoxUpDoubleAndRight,
        /// <summary>╔</summary>
        BoxDownDoubleAndRight,
        /// <summary>╩</summary>
        BoxHorizontalDoubleAndUp,
        /// <summary>╦</summary>
        BoxHorizontalDoubleAndDown,
        /// <summary>╠</summary>
        BoxVerticalDoubleAndRight,
        /// <summary>═</summary>
        BoxHorizontalDouble,
        /// <summary>╬</summary>
        BoxHorizontalDoubleAndVertical,
        /// <summary>╧</summary>
        BoxHorizontalDoubleAndUpSingle,
        /// <summary>╨</summary>
        BoxHorizontalSingleAndUpDouble,
        /// <summary>╤</summary>
        BoxHorizontalDoubleAndDownSingle,
        /// <summary>╥</summary>
        BoxHorizontalSingleAndDownDouble,
        /// <summary>╙</summary>
        BoxUpDoubleAndRightSingle,
        /// <summary>╘</summary>
        BoxUpSingleAndRightDouble,
        /// <summary>╒</summary>
        BoxDownSingleAndRightDouble,
        /// <summary>╓</summary>
        BoxDownDoubleAndRightSingle,
        /// <summary>╫</summary>
        BoxHorizontalSingleAndVerticalDouble,
        /// <summary>╪</summary>
        BoxHorizontalDoubleAndVerticalSingle,
        /// <summary>┘</summary>
        BoxUpSingleAndLeft,
        /// <summary>┌</summary>
        BoxDownSingleAndLeft,
        /// <summary>█</summary>
        FullBlock,
        /// <summary>▄</summary>
        LowerHalfBlock,
        /// <summary>▌</summary>
        LeftHalfBlock,
        /// <summary>▐</summary>
        RightHalfBlock,
        /// <summary>▀</summary>
        UpperHalfBlock,
        /// <summary>α</summary>
        SmallAlpha,
        /// <summary>β</summary>
        CapitalBeta,
        /// <summary>Γ</summary>
        CapitalGamma,
        /// <summary>π</summary>
        SmallPi,
        /// <summary>𝚺</summary>
        CapitalSigma,
        /// <summary>σ</summary>
        SmallSigma,
        /// <summary>ᵞ</summary>
        SmallGamma,
        /// <summary>𝝉</summary>
        SmallTau,
        /// <summary>⧲</summary>
        ErrorBarredWhiteCircle,
        /// <summary>θ</summary>
        SmallTheta,
        /// <summary>Ω</summary>
        CapitalOmega,
        /// <summary>δ</summary>
        SmallDelta,
        /// <summary>ↀ</summary>
        RomanNumeral1000,
        /// <summary>ø</summary>
        LatinSmallOWithStroke,
        /// <summary>ϵ</summary>
        LunateEpsilon,
        /// <summary>Π</summary>
        CapicalPi,
        /// <summary>≡</summary>
        IdenticalSymbol,
        /// <summary>±</summary>
        PlusMinus,
        /// <summary>≥</summary>
        GreaterThanOrEqual,
        /// <summary>≤</summary>
        LessThanOrEqual,
        /// <summary>⌠</summary>
        TopHalfIntegral,
        /// <summary>⌡</summary>
        BottomHalfIntegral,
        /// <summary>÷</summary>
        DivisionSymbol,
        /// <summary>≈</summary>
        AlmostEqual,
        /// <summary>°</summary>
        DegreeSign,
        /// <summary>·</summary>
        MiddleDot,
        /// <summary>ᐧ</summary>
        FinalMiddleDot,
        /// <summary>√</summary>
        SquareRootSymbol,
        /// <summary>ⁿ</summary>
        SuperScriptSmallN,
        /// <summary>²</summary>
        SuperScript2,
        /// <summary>∎</summary>
        EndOfProof
    }
}

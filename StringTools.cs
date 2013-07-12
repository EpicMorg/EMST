using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
#if DEBUG
using System.Diagnostics;
using System.Text;
#endif
namespace EpicMorg.Tools {
	public class StringTools {
		Regex numeric = new Regex( "\\&\\#[0-9]{1,5}\\;" );
		Regex urlhex = new Regex( "(\\%[0-9A-Fa-f]{2}){2}" );
		Random random = new Random();
		#region ASCII
		public char[] _ascii_chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~' };
		public byte[] _ascii_chars_bytes = { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 58, 59, 60, 61, 62, 63, 64, 91, 92, 93, 94, 95, 96, 123, 124, 125, 126 };
		public ushort[] _offsets = { 0, 0, 33, 48, 65, 97 };
		public ushort[] _lengs = { 65535, 32, 32, 10, 26, 26 };
		#endregion
		#region Chars
		static char[] Chars = "\"&'1<>¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿŒœŠšŸƒˆ˜ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩαβγδεζηθικλμνξοπρςστυφχψωϑϒϖ   ‎‏–—‘’‚“”„†‡•…‰′″‹›‾⁄€ℑ℘ℜ™ℵ←↑→↓↔↵⇐⇑⇒⇓⇔∀∂∃∅∇∈∉∋∏∑−∗√∝∞∠∧∨∩∪∫∴∼≅≈≠≡≤≥⊂⊃⊄⊆⊇⊕⊗⊥⋅⌈⌉⌊⌋◊♠♣♥♦〈〉".ToCharArray();
		#endregion
		#region HTMLEntities
		Dictionary<char, string> Entities = new Dictionary<char, string>() {{'Á',"&Aacute;"},{'\'',"&#39;"},{'á',"&aacute;"},{'â',"&acirc;"},{'Â',"&Acirc;"},{'´',"&acute;"},{'æ',"&aelig;"},{'Æ',"&AElig;"},{'À',"&Agrave;"},{'à',"&agrave;"},{'ℵ',"&alefsym;"},{'Α',"&Alpha;"},{'α',"&alpha;"},{'&',"&amp;"},{'∧',"&and;"},{'∠',"&ang;"},{'å',"&aring;"},{'Å',"&Aring;"},{'≈',"&asymp;"},{'Ã',"&Atilde;"},{'ã',"&atilde;"},{'Ä',"&Auml;"},{'ä',"&auml;"},{'„',"&bdquo;"},{'Β',"&Beta;"},{'β',"&beta;"},{'¦',"&brvbar;"},{'•',"&bull;"},{'∩',"&cap;"},{'Ç',"&Ccedil;"},{'ç',"&ccedil;"},{'¸',"&cedil;"},{'¢',"&cent;"},{'χ',"&chi;"},{'Χ',"&Chi;"},{'ˆ',"&circ;"},{'♣',"&clubs;"},{'≅',"&cong;"},{'©',"&copy;"},{'↵',"&crarr;"},{'∪',"&cup;"},{'¤',"&curren;"},{'†',"&dagger;"},{'‡',"&Dagger;"},{'⇓',"&dArr;"},{'↓',"&darr;"},{'°',"&deg;"},{'Δ',"&Delta;"},{'δ',"&delta;"},{'♦',"&diams;"},{'÷',"&divide;"},{'é',"&eacute;"},{'É',"&Eacute;"},{'Ê',"&Ecirc;"},{'ê',"&ecirc;"},{'è',"&egrave;"},{'È',"&Egrave;"},{'∅',"&empty;"},{' ',"&emsp;"},{' ',"&ensp;"},{'ε',"&epsilon;"},{'Ε',"&Epsilon;"},{'≡',"&equiv;"},{'Η',"&Eta;"},{'η',"&eta;"},{'ð',"&eth;"},{'Ð',"&ETH;"},{'ë',"&euml;"},{'Ë',"&Euml;"},{'€',"&euro;"},{'∃',"&exist;"},{'ƒ',"&fnof;"},{'∀',"&forall;"},{'½',"&frac12;"},{'¼',"&frac14;"},{'¾',"&frac34;"},{'⁄',"&frasl;"},{'Γ',"&Gamma;"},{'γ',"&gamma;"},{'≥',"&ge;"},{'>',"&gt;"},{'⇔',"&hArr;"},{'↔',"&harr;"},{'♥',"&hearts;"},{'…',"&hellip;"},{'í',"&iacute;"},{'Í',"&Iacute;"},{'î',"&icirc;"},{'Î',"&Icirc;"},{'¡',"&iexcl;"},{'Ì',"&Igrave;"},{'ì',"&igrave;"},{'ℑ',"&image;"},{'∞',"&infin;"},{'∫',"&int;"},{'Ι',"&Iota;"},{'ι',"&iota;"},{'¿',"&iquest;"},{'∈',"&isin;"},{'Ï',"&Iuml;"},{'ï',"&iuml;"},{'Κ',"&Kappa;"},{'κ',"&kappa;"},{'λ',"&lambda;"},{'Λ',"&Lambda;"},{'〈',"&lang;"},{'«',"&laquo;"},{'←',"&larr;"},{'⇐',"&lArr;"},{'⌈',"&lceil;"},{'“',"&ldquo;"},{'≤',"&le;"},{'⌊',"&lfloor;"},{'∗',"&lowast;"},{'◊',"&loz;"},{'‎',"&lrm;"},{'‹',"&lsaquo;"},{'‘',"&lsquo;"},{'<',"&lt;"},{'¯',"&macr;"},{'—',"&mdash;"},{'µ',"&micro;"},{'·',"&middot;"},{'−',"&minus;"},{'Μ',"&Mu;"},{'μ',"&mu;"},{'∇',"&nabla;"},{'1',"&1;"},{'–',"&ndash;"},{'≠',"&ne;"},{'∋',"&ni;"},{'¬',"&not;"},{'∉',"&notin;"},{'⊄',"&nsub;"},{'ñ',"&ntilde;"},{'Ñ',"&Ntilde;"},{'Ν',"&Nu;"},{'ν',"&nu;"},{'ó',"&oacute;"},{'Ó',"&Oacute;"},{'Ô',"&Ocirc;"},{'ô',"&ocirc;"},{'Œ',"&OElig;"},{'œ',"&oelig;"},{'ò',"&ograve;"},{'Ò',"&Ograve;"},{'‾',"&oline;"},{'ω',"&omega;"},{'Ω',"&Omega;"},{'Ο',"&Omicron;"},{'ο',"&omicron;"},{'⊕',"&oplus;"},{'∨',"&or;"},{'ª',"&ordf;"},{'º',"&ordm;"},{'Ø',"&Oslash;"},{'ø',"&oslash;"},{'Õ',"&Otilde;"},{'õ',"&otilde;"},{'⊗',"&otimes;"},{'Ö',"&Ouml;"},{'ö',"&ouml;"},{'¶',"&para;"},{'∂',"&part;"},{'‰',"&permil;"},{'⊥',"&perp;"},{'φ',"&phi;"},{'Φ',"&Phi;"},{'Π',"&Pi;"},{'π',"&pi;"},{'ϖ',"&piv;"},{'±',"&plusmn;"},{'£',"&pound;"},{'″',"&Prime;"},{'′',"&prime;"},{'∏',"&prod;"},{'∝',"&prop;"},{'ψ',"&psi;"},{'Ψ',"&Psi;"},{'"',"&quot;"},{'√',"&radic;"},{'〉',"&rang;"},{'»',"&raquo;"},{'⇒',"&rArr;"},{'→',"&rarr;"},{'⌉',"&rceil;"},{'”',"&rdquo;"},{'ℜ',"&real;"},{'®',"&reg;"},{'⌋',"&rfloor;"},{'Ρ',"&Rho;"},{'ρ',"&rho;"},{'‏',"&rlm;"},{'›',"&rsaquo;"},{'’',"&rsquo;"},{'‚',"&sbquo;"},{'Š',"&Scaron;"},{'š',"&scaron;"},{'⋅',"&sdot;"},{'§',"&sect;"},{'­',"&shy;"},{'Σ',"&Sigma;"},{'σ',"&sigma;"},{'ς',"&sigmaf;"},{'∼',"&sim;"},{'♠',"&spades;"},{'⊂',"&sub;"},{'⊆',"&sube;"},{'∑',"&sum;"},{'⊃',"&sup;"},{'¹',"&sup1;"},{'²',"&sup2;"},{'³',"&sup3;"},{'⊇',"&supe;"},{'ß',"&szlig;"},{'Τ',"&Tau;"},{'τ',"&tau;"},{'∴',"&there4;"},{'Θ',"&Theta;"},{'θ',"&theta;"},{'ϑ',"&thetasym;"},{' ',"&thinsp;"},{'Þ',"&THORN;"},{'þ',"&thorn;"},{'˜',"&tilde;"},{'×',"&times;"},{'™',"&trade;"},{'ú',"&uacute;"},{'Ú',"&Uacute;"},{'⇑',"&uArr;"},{'↑',"&uarr;"},{'û',"&ucirc;"},{'Û',"&Ucirc;"},{'Ù',"&Ugrave;"},{'ù',"&ugrave;"},{'¨',"&uml;"},{'ϒ',"&upsih;"},{'υ',"&upsilon;"},{'Υ',"&Upsilon;"},{'ü',"&uuml;"},{'Ü',"&Uuml;"},{'℘',"&weierp;"},{'ξ',"&xi;"},{'Ξ',"&Xi;"},{'ý',"&yacute;"},{'Ý',"&Yacute;"},{'¥',"&yen;"},{'ÿ',"&yuml;"},{'Ÿ',"&Yuml;"},{'Ζ',"&Zeta;"},{'ζ',"&zeta;"},
		};
		#endregion
		#region Reversed entities
		private static Dictionary<string, char> ReversedEntities = new Dictionary<string, char>{{"&#039;",'\''},{"&Aacute;",'Á'},{"&aacute;",'á'},{"&acirc;",'â'},{"&Acirc;",'Â'},{"&acute;",'´'},{"&aelig;",'æ'},{"&AElig;",'Æ'},{"&Agrave;",'À'},{"&agrave;",'à'},{"&alefsym;",'ℵ'},{"&Alpha;",'Α'},{"&alpha;",'α'},{"&amp;",'&'},{"&and;",'∧'},{"&ang;",'∠'},{"&aring;",'å'},{"&Aring;",'Å'},{"&asymp;",'≈'},{"&Atilde;",'Ã'},{"&atilde;",'ã'},{"&Auml;",'Ä'},{"&auml;",'ä'},{"&bdquo;",'„'},{"&Beta;",'Β'},{"&beta;",'β'},{"&brvbar;",'¦'},{"&bull;",'•'},{"&cap;",'∩'},{"&Ccedil;",'Ç'},{"&ccedil;",'ç'},{"&cedil;",'¸'},{"&cent;",'¢'},{"&chi;",'χ'},{"&Chi;",'Χ'},{"&circ;",'ˆ'},{"&clubs;",'♣'},{"&cong;",'≅'},{"&copy;",'©'},{"&crarr;",'↵'},{"&cup;",'∪'},{"&curren;",'¤'},{"&dagger;",'†'},{"&Dagger;",'‡'},{"&dArr;",'⇓'},{"&darr;",'↓'},{"&deg;",'°'},{"&Delta;",'Δ'},{"&delta;",'δ'},{"&diams;",'♦'},{"&divide;",'÷'},{"&eacute;",'é'},{"&Eacute;",'É'},{"&Ecirc;",'Ê'},{"&ecirc;",'ê'},{"&egrave;",'è'},{"&Egrave;",'È'},{"&empty;",'∅'},{"&emsp;",' '},{"&ensp;",' '},{"&epsilon;",'ε'},{"&Epsilon;",'Ε'},{"&equiv;",'≡'},{"&Eta;",'Η'},{"&eta;",'η'},{"&eth;",'ð'},{"&ETH;",'Ð'},{"&euml;",'ë'},{"&Euml;",'Ë'},{"&euro;",'€'},{"&exist;",'∃'},{"&fnof;",'ƒ'},{"&forall;",'∀'},{"&frac12;",'½'},{"&frac14;",'¼'},{"&frac34;",'¾'},{"&frasl;",'⁄'},{"&Gamma;",'Γ'},{"&gamma;",'γ'},{"&ge;",'≥'},{"&gt;",'>'},{"&hArr;",'⇔'},{"&harr;",'↔'},{"&hearts;",'♥'},{"&hellip;",'…'},{"&iacute;",'í'},{"&Iacute;",'Í'},{"&icirc;",'î'},{"&Icirc;",'Î'},{"&iexcl;",'¡'},{"&Igrave;",'Ì'},{"&igrave;",'ì'},{"&image;",'ℑ'},{"&infin;",'∞'},{"&int;",'∫'},{"&Iota;",'Ι'},{"&iota;",'ι'},{"&iquest;",'¿'},{"&isin;",'∈'},{"&Iuml;",'Ï'},{"&iuml;",'ï'},{"&Kappa;",'Κ'},{"&kappa;",'κ'},{"&lambda;",'λ'},{"&Lambda;",'Λ'},{"&lang;",'〈'},{"&laquo;",'«'},{"&larr;",'←'},{"&lArr;",'⇐'},{"&lceil;",'⌈'},{"&ldquo;",'“'},{"&le;",'≤'},{"&lfloor;",'⌊'},{"&lowast;",'∗'},{"&loz;",'◊'},{"&lrm;",'‎'},{"&lsaquo;",'‹'},{"&lsquo;",'‘'},{"&lt;",'<'},{"&macr;",'¯'},{"&mdash;",'—'},{"&micro;",'µ'},{"&middot;",'·'},{"&minus;",'−'},{"&Mu;",'Μ'},{"&mu;",'μ'},{"&nabla;",'∇'},{"&1;",'1'},{"&ndash;",'–'},{"&ne;",'≠'},{"&ni;",'∋'},{"&not;",'¬'},{"&notin;",'∉'},{"&nsub;",'⊄'},{"&ntilde;",'ñ'},{"&Ntilde;",'Ñ'},{"&Nu;",'Ν'},{"&nu;",'ν'},{"&oacute;",'ó'},{"&Oacute;",'Ó'},{"&Ocirc;",'Ô'},{"&ocirc;",'ô'},{"&OElig;",'Œ'},{"&oelig;",'œ'},{"&ograve;",'ò'},{"&Ograve;",'Ò'},{"&oline;",'‾'},{"&omega;",'ω'},{"&Omega;",'Ω'},{"&Omicron;",'Ο'},{"&omicron;",'ο'},{"&oplus;",'⊕'},{"&or;",'∨'},{"&ordf;",'ª'},{"&ordm;",'º'},{"&Oslash;",'Ø'},{"&oslash;",'ø'},{"&Otilde;",'Õ'},{"&otilde;",'õ'},{"&otimes;",'⊗'},{"&Ouml;",'Ö'},{"&ouml;",'ö'},{"&para;",'¶'},{"&part;",'∂'},{"&permil;",'‰'},{"&perp;",'⊥'},{"&phi;",'φ'},{"&Phi;",'Φ'},{"&Pi;",'Π'},{"&pi;",'π'},{"&piv;",'ϖ'},{"&plusmn;",'±'},{"&pound;",'£'},{"&Prime;",'″'},{"&prime;",'′'},{"&prod;",'∏'},{"&prop;",'∝'},{"&psi;",'ψ'},{"&Psi;",'Ψ'},{"&quot;",'"'},{"&radic;",'√'},{"&rang;",'〉'},{"&raquo;",'»'},{"&rArr;",'⇒'},{"&rarr;",'→'},{"&rceil;",'⌉'},{"&rdquo;",'”'},{"&real;",'ℜ'},{"&reg;",'®'},{"&rfloor;",'⌋'},{"&Rho;",'Ρ'},{"&rho;",'ρ'},{"&rlm;",'‏'},{"&rsaquo;",'›'},{"&rsquo;",'’'},{"&sbquo;",'‚'},{"&Scaron;",'Š'},{"&scaron;",'š'},{"&sdot;",'⋅'},{"&sect;",'§'},{"&shy;",'­'},{"&Sigma;",'Σ'},{"&sigma;",'σ'},{"&sigmaf;",'ς'},{"&sim;",'∼'},{"&spades;",'♠'},{"&sub;",'⊂'},{"&sube;",'⊆'},{"&sum;",'∑'},{"&sup;",'⊃'},{"&sup1;",'¹'},{"&sup2;",'²'},{"&sup3;",'³'},{"&supe;",'⊇'},{"&szlig;",'ß'},{"&Tau;",'Τ'},{"&tau;",'τ'},{"&there4;",'∴'},{"&Theta;",'Θ'},{"&theta;",'θ'},{"&thetasym;",'ϑ'},{"&thinsp;",' '},{"&THORN;",'Þ'},{"&thorn;",'þ'},{"&tilde;",'˜'},{"&times;",'×'},{"&trade;",'™'},{"&uacute;",'ú'},{"&Uacute;",'Ú'},{"&uArr;",'⇑'},{"&uarr;",'↑'},{"&ucirc;",'û'},{"&Ucirc;",'Û'},{"&Ugrave;",'Ù'},{"&ugrave;",'ù'},{"&uml;",'¨'},{"&upsih;",'ϒ'},{"&upsilon;",'υ'},{"&Upsilon;",'Υ'},{"&uuml;",'ü'},{"&Uuml;",'Ü'},{"&weierp;",'℘'},{"&xi;",'ξ'},{"&Xi;",'Ξ'},{"&yacute;",'ý'},{"&Yacute;",'Ý'},{"&yen;",'¥'},{"&yuml;",'ÿ'},{"&Yuml;",'Ÿ'},{"&Zeta;",'Ζ'},{"&zeta;",'ζ'},
			};
		#endregion
		public enum ReplaceType {
			HtmlEntity,
			CharacterCode,
			Both
		}
		public string ToHex( long i ) {
			if ( i == 0 ) return "0";
			int sz = 0;
			if ( i < 0 ) {
				sz++;
				i *= -1;
			}
			long copy = i;
			while ( ( i >>= 4 ) > 0 ) sz++;
			char[] output = new char[ sz + 1 ];
			output[ 0 ] = '-';
			do output[ sz-- ] = _ascii_chars[ copy & 0x0fL ]; while ( ( copy >>= 4 ) > 0 );
			return new string( output );
		}
		public string ToHex( int i ) {
			if ( i == 0 ) return "0";
			int sz = 0;
			if ( i < 0 ) {
				sz++;
				i *= -1;
			}
			int copy = i;
			while ( ( i >>= 4 ) > 0 ) sz++;
			char[] output = new char[ sz + 1 ];
			output[ 0 ] = '-';
			do output[ sz-- ] = _ascii_chars[ copy & 0x0fL ]; while ( ( copy >>= 4 ) > 0 );
			return new string( output );
		}
		public string ToHex( byte[] bytes ) {
			if ( bytes == null ) {
				throw new ArgumentNullException( "bytes" );
			}
			int length = bytes.Length * 2;
			char[] hex = new char[ length ];
			int byteIndex = 0;
			for ( int charIndex = 0; charIndex < length; charIndex += 2 ) {
				byte byteValue = bytes[ byteIndex++ ];
				hex[ charIndex ] = _ascii_chars[ byteValue >> 4 ];
				hex[ charIndex + 1 ] = _ascii_chars[ byteValue & 0x0F ];
			}
			return new string( hex );
		}
		public string HtmlSpecialChars( string s ) {
			foreach ( char c in s.ToCharArray().Distinct().ToArray() )
				if ( Entities.ContainsKey( c ) )
					s = s.Replace( c.ToString(), Entities[ c ] );
			return s;
		}
		public string HtmlSpecialCharsDecode( string s ) {
			return HtmlSpecialCharsDecode( s, ReplaceType.Both );
		}
		public string HtmlSpecialCharsDecode( string s, ReplaceType r ) {
			if ( r == ReplaceType.CharacterCode || r == ReplaceType.Both )
				s = numeric.Replace( s, new MatchEvaluator( rep ) );
			if ( r == ReplaceType.HtmlEntity || r == ReplaceType.Both )
				foreach ( var x in ReversedEntities.Keys.Where( o => s.Contains( o ) ).ToArray() )
					s = s.Replace( x, ReversedEntities[ x ].ToString() );
			return s;
		}
		public string UrlDecode( string s ) {
			return urlhex.Replace( s, new MatchEvaluator( rep2 ) );
		}
		public string UrlEncode( string s ) {
			return "%" + BitConverter.ToString( Encoding.UTF8.GetBytes( s ) ).Replace( '-', '%' );
		}
		string rep2( Match m ) {
			string s = m.ToString();
			s = Convert.ToChar( int.Parse( s.Substring( 2, s.Length - 3 ), System.Globalization.NumberStyles.HexNumber ) ).ToString();
			return s;
		}
		string rep( Match m ) {
			string s = m.ToString();
			s = Convert.ToChar( int.Parse( s.Substring( 2, s.Length - 3 ) ) ).ToString();
			return s;
		}
		public int QuickIntParse( char[] input ) {
			return QuickIntParse( input, 0, input.Length );
		}
		public int QuickIntParse( char[] input, int from, int count ) {
			int sum = 0, cnt = 0;
			bool pos = true;
			if ( input[ from ] == '-' ) {
				pos = false;
				cnt++;
			}
			while ( cnt < count ) {
				sum *= 10;
				sum += ( ( int ) input[ ( cnt++ ) + from ] ) - 48;
			}
			return pos ? sum : -sum;
		}
		public unsafe int QuickIntParse( char* input, int from, int count ) {
			int sum = 0;//, cnt = 0;
			input += from;
			char* end = input + count;
			bool pos = true;
			if ( *input == '-' ) {
				pos = false;
				input++;
			}
			while ( input < end ) {
				sum *= 10;
				sum += *( input++ ) - '0';
			}
			return pos ? sum : -sum;
		}
		public long QuickLongParse( char[] input ) {
			return QuickLongParse( input, 0, input.Length );
		}
		public unsafe int QuickLongParse( string s ) {
			fixed ( char* p = s ) return QuickIntParse( p, 0, s.Length );
		}
		public unsafe long QuickLongParse( char[] input, int from, int count ) {
			fixed ( char* cinput = input )
				return QuickLongParse( cinput, from, count );
		}
		public unsafe long QuickLongParse( char* input, int from, int count ) {
			long sum = 0;//, cnt = 0;
			input += from;
			char* end = input + count;
			bool pos = true;
			if ( *input == '-' ) {
				pos = false;
				input++;
			}
			while ( input < end ) {
				sum = sum * 10 + *( input++ ) - '0';
			}
			return pos ? sum : -sum;
		}
		public char[] RandomAsciiChars( int min_len, int max_len ) {
			return RandomAsciiChars( min_len, max_len, _ascii_chars, 0, _ascii_chars.Length - 1 );
		}
		public char[] RandomAsciiChars( int min_len, int max_len, char[] source, int startindex, int maxindex ) {
			int rnd = random.Next( min_len, max_len + 1 );
			char[] output = new char[ rnd ];
			for ( int i = 0; i < rnd; output[ i++ ] = _ascii_chars[ random.Next( startindex, maxindex + 1 ) ] ) ;
			return output;
		}
		public char[] RandomUTFUrlencodeChars( int min_real_len, int max_real_len ) {
			int len = random.Next( min_real_len, max_real_len ) * 6;
			char[] output = new char[ len ];
			ushort rnd = 0;
			for ( int i = 0; i < len; ) {
				rnd = ( ushort ) random.Next( 1, 65535 );
				output[ i++ ] = '%';
				output[ i++ ] = _ascii_chars[ rnd >> 12 ];
				output[ i++ ] = _ascii_chars[ ( rnd >> 8 ) & 0xf ];
				output[ i++ ] = '%';
				output[ i++ ] = _ascii_chars[ ( rnd >> 4 ) & 0xf ];
				output[ i++ ] = _ascii_chars[ rnd & 0xf ];
			}
			return output;
		}
	}
}
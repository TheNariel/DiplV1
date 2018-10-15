\newif\ifPlain \newif\ifLaTeX
\ifx\documentclass\undefined
  \Plaintrue \LaTeXfalse
  \input opmac
  \catcode`\@=11
\else
  \Plainfalse \LaTeXtrue
\fi
\let\ea\expandafter
\long\def\long@empty{}
\ifPlain
  \let\@namedef\sdef
  \def\@nameuse#1{\csname#1\endcsname}
  \def\@empty{}
  \long\def\@firstofone#1{#1}
  \newlinechar10
  \def\Message#{\immediate\write16}
  \def\ProvidesClass#1[#2]{\Message{Document Class: #1 #2}}
  \def\ClassError#1#2#3{\Message{Class #1 Error:}%
    {\errorcontextlines0
    \edef\x{#3}\ea\errhelp\ea{\x}%
    \errmessage{#2}}}
  \def\DeclareOption#1#2{\sdef{#1}{#2}%
    \ea\@onlypreamble\csname#1\endcsname}
  \def\clearpage{\par\vfil\break}
  \def\normalsize{\typobase}
  \def\large{\typobase\typoscale[1200/1200]}
  \def\Large{\typobase\typoscale[1440/1440]}
  \def\huge{\typobase\typoscale[2074/2074]}
  \def\normalfont{\rm}
  \font\sc=cscsc10 at12pt \regfont\sc
  \def\AtBeginDocument#1{\OP@addto\ABDqueue{#1}}
  \def\ABDqueue{}
  \def\@onlypreamble#1{\AtBeginDocument{\preamble@only#1}}
  \def\preamble@only#1{\def#1{\p@oerr#1}}
  \def\p@oerr#1{\JS@ClassError
    {V dokumentu nelze pouzit \string#1}
    {Makro \string#1 se pouziva pouze pred
      \string\pocatecnistrany.}}
  \def\@ifnextchar#1#2#3{\let\@tempe #1\def\@tempa:{#2}%
    \def\@tempb:{#3}\futurelet \@tempc\@ifnch}
  \def\@ifnch{\ifx \@tempc \@sptoken \let\@tempd\@xifnch
    \else \ifx \@tempc\@tempe \let\@tempd\@tempa
    \else \let\@tempd\@tempb
    \fi
    \fi \@tempd:}
  \futurelet\@sptoken{ } % toto taky vkládá space token
  \def\@xifnch: {\futurelet\@tempc\@ifnch}
\fi
\ifLaTeX
  \def\adef#1{\catcode`#1=13
    \begingroup \lccode`\~=`#1\lowercase{\endgroup\def~}}
  \let\testin\@inputcheck
\fi
\ifPlain
  \def\JS@pagestyleempty{\headline{\hss}\footline{\hss}}
\else
  \def\JS@pagestyleempty{\pagestyle{empty}}
\fi
\def\JS@begincenter{\begingroup
  \leftskip0ptplus1fil \rightskip\leftskip
  \parindent0pt \parfillskip0pt \hyphenpenalty10000
  \noindent}
\def\JS@endcenter{\par\endgroup}
\def\OP@addto#1#2{\ea\def\ea#1\ea{#1#2}}
\def\JS@inpreamble#1{\ea\@onlypreamble\csname#1\endcsname
  \@namedef{JS@ABD@#1}{\JS@nepouzito{#1}}
  \ea\AtBeginDocument\csname JS@ABD@#1\endcsname}
\def\JS@pouzito#1{\@namedef{JS@ABD@#1}{}}
\ifPlain
  \def\JS@nepouzito#1{\JS@ClassError
    {Neni pouzito \ea\string\csname#1\endcsname}
    {Pred \string\pocatecnistrany\space pouzijte
      \ea\string\csname#1\endcsname.}}
\else
  \def\JS@nepouzito#1{\JS@ClassError
    {Neni pouzito \ea\string\csname#1\endcsname}
    {Pred \string\begin{document} pouzijte
      \ea\string\csname#1\endcsname.}}
\fi
\def\JS@novepole#1{
  \@namedef{#1}##1{\JS@pouzito{#1}\@namedef{#1@}{##1}}
  \@nameuse{#1}{#1}
  \JS@inpreamble{#1}}
\def\JS@novelongpole#1{
  \long\@namedef{#1}##1{\JS@pouzito{#1}
    \long\@namedef{#1@}{##1}}
  \@nameuse{#1}{#1}
  \JS@inpreamble{#1}}
\def\JS@noveCZENpole#1{
  \@namedef{#1}##1##2{\JS@pouzito{#1}\@namedef{#1@CZ}{##1}
    \@namedef{#1@EN}{##2}}
  \@nameuse{#1}{#1}{#1}
  \JS@inpreamble{#1}}
\def\JS@novelongCZENpole#1{
  \long\@namedef{#1}##1##2{\JS@pouzito{#1}
    \long\@namedef{#1@CZ}{##1}
    \long\@namedef{#1@EN}{##2}}
  \@nameuse{#1}{#1}{#1}
  \JS@inpreamble{#1}}
\def\JS@ClassName{vskpou}
\ifLaTeX
  \NeedsTeXFormat{LaTeX2e}
\fi
\ProvidesClass{\JS@ClassName}[2015/01/23 v2.0^^JTrida
  pro sazbu kvalifikacnich praci na Ostravske univerzite.]
\def\JS@ClassError{\ClassError{\JS@ClassName}}
\newif\ifJS@oneside
\newif\ifJS@samepage
\newif\ifJS@old
\def\JS@nastavold{\JS@oldtrue
  \JS@pouzito{resume}}
\JS@noveCZENpole{nadpisresume}
\JS@novelongCZENpole{resume}
\let\JS@clearpage\clearpage
\DeclareOption{oneside}{\JS@onesidetrue}
\DeclareOption{samepage}{\JS@samepagetrue}
\DeclareOption{sectionright}
  {\let\JS@clearpage\JS@cleardoublepage}
\DeclareOption{old}{\JS@nastavold}
\ifPlain
  \DeclareOption{final}{\overfullrule=0pt}
\fi
\ifLaTeX
  \DeclareOption*{\PassOptionsToClass{\CurrentOption}{article}}
  \ProcessOptions
\fi
\def\centerpwline#1{\hbox to \paperwidth{\hss#1\hss}}
\newbox\boxa
\def\scale#1#2{{\setbox\boxa=\hbox{#2}%
  \hbox{\pdfliteral{q #1 0 0 #1 0 0 cm}%
  \rlap{\smash{#2}}\pdfliteral{Q}%
  \vrule width0pt height#1\ht\boxa depth#1\dp\boxa \kern#1\wd\boxa}}}
\def\xscale#1#2{{\setbox\boxa=\hbox{#2}%
  \hbox{\pdfliteral{q #1 0 0 1 0 0 cm}%
  \rlap{\smash{#2}}\pdfliteral{Q}%
  \vrule width0pt height\ht\boxa depth\dp\boxa \kern#1\wd\boxa}}}
\def\leftbox#1#{\lboxA{#1}}
\def\centerbox#1#{\cboxA{#1}}
\def\rightbox#1#{\rboxA{#1}}
\def\lboxA#1#2{\hbox to #1{\lcrboxB{#1}{#2}\hfil}}
\def\cboxA#1#2{\hbox to #1{\hfil\lcrboxB{#1}{#2}\hfil}}
\def\rboxA#1#2{\hbox to #1{\hfil\lcrboxB{#1}{#2}}}
\newdimen\lcrdimen
\newcount\lcrcount
\def\lcrboxB#1#2{\lcrdimen#1%
  \setbox0=\hbox{#2}%
  \ifdim\wd0>\lcrdimen
    \def\lcrnext{\lcrboxC{#2}}%
  \else
    \def\lcrnext{#2}%
  \fi
  \lcrnext}
\def\lcrboxC#1{\lcrcount1000
  \loop
    \dimen0=0.001\wd0 % kvuli preteceni
    \dimen2=0.001\lcrdimen
    \ifdim\lcrcount\dimen0>1000\dimen2
    \advance\lcrcount-2
  \repeat
  \ifnum\lcrcount<10
    \xscale{0.00\the\lcrcount}{#1}%
  \else\ifnum\lcrcount<100
    \xscale{0.0\the\lcrcount}{#1}%
  \else
    \xscale{0.\the\lcrcount}{#1}%
  \fi\fi}
\ifPlain
  \input opmac
  \typosize[12/14]
  \advance\baselineskip by0ptplus0.2pt
  \parindent24pt
  \iindent\parindent
  \ttindent\parindent
  \ifJS@oneside
    \margins/1 a4 (35,25,30,30)mm
  \else
    \margins/2 a4 (35,25,30,30)mm
  \fi
\else
  \ifJS@oneside
    \LoadClass[a4paper,12pt,oneside]{article}
  \else
    \LoadClass[a4paper,12pt,twoside]{article}
  \fi
  \RequirePackage[top=3cm,bottom=3cm,left=35mm,right=25mm]
      {geometry}
  \flushbottom
\fi
\ifPlain
  \def\JS@uppercase#1{\ea\uppercase\ea{#1}}
\else
  \def\JS@uppercase#1{\ea\MakeUppercase\ea{#1}}
\fi
\def\JS@strut{\vphantom{j\v C}}
\ifPlain
  \hyperlinks{}{}
  \def\refborder{1 0 0}
  \def\tocborder{1 0 0}
  \def\pgborder{1 0 0}
  \def\citeborder{0 1 0}
  \def\urlborder{1 0 0}
\else
  \RequirePackage[unicode,pdftex,colorlinks=false,pdfview=fit,
    bookmarksnumbered=true,bookmarksopen=true]{hyperref}
\fi
\JS@noveCZENpole{univerzita}
\JS@noveCZENpole{fakulta}
\JS@noveCZENpole{katedra}
\JS@noveCZENpole{typprace}
\JS@noveCZENpole{nazev}
\JS@novepole{autor}
\JS@novepole{vedouci}
\JS@novepole{rok}
\JS@novelongpole{podekovani}
\newif\ifJS@MMXVII
\let\JS@orirok\rok
\def\rok#1{\JS@orirok{#1}%
  \ifnum\rok@<2016 \JS@nastavold\fi
  \ifnum\rok@>2016 \JS@MMXVIItrue\else\JS@MMXVIIfalse\fi}
\JS@noveCZENpole{nadpisabstraktu}
\JS@novelongCZENpole{abstrakt}
\JS@noveCZENpole{nadpisklicovychslov}
\JS@novelongCZENpole{klicovaslova}
\JS@noveCZENpole{nadpisautora}
\JS@noveCZENpole{nadpisvedouciho}
\let\ori@klicovaslova\klicovaslova
\def\klicovaslova{\catcode`\,=13 \klicovaslova@A}
\def\klicovaslova@A#1#2{\ori@klicovaslova{#1}{#2}
  \catcode`\,=12}
\JS@novepole{pohlavi}
\def\JS@koncovka@M{} \def\JS@koncovka@m{}
\def\JS@koncovka@Z{a}\def\JS@koncovka@z{a}
\def\JS@koncovka@F{a}\def\JS@koncovka@f{a}
\def\JS@koncovka{\ea\ifx\csname JS@koncovka@\pohlavi@\endcsname
    \relax
  (a)\else\@nameuse{JS@koncovka@\pohlavi@}\fi}
\def\JS@pohlavi@M{M} \def\JS@pohlavi@m{M}
\def\JS@pohlavi@Z{Z} \def\JS@pohlavi@z{Z}
\def\JS@pohlavi@F{Z} \def\JS@pohlavi@f{Z}
\def\JS@koncovka#1#2#3{\def\JS@koncovkaM{#1}%
  \def\JS@koncovkaZ{#2}\def\JS@koncovkaX{#3}%
  \ea\ifx\csname JS@pohlavi@\pohlavi@\endcsname\relax
    \JS@koncovkaX \else \csname JS@koncovka\csname
      JS@pohlavi@\pohlavi@\endcsname\endcsname\fi}
\def\prohlaseni{\JS@pouzito{prohlaseni}
  \@ifnextchar[\JS@prohlaseniA\JS@prohlaseniB}
\long\def\JS@prohlaseniA[#1]{\long\def\JS@textprohlaseni{#1}
  \JS@prohlaseniB}
\def\JS@prohlaseniB#1{\def\JS@datumprohlaseni{#1}}
\JS@inpreamble{prohlaseni}
\def\JS@textprohlaseni{\ifPlain
    \cslang
  \else
    \selectlanguage{czech}%
  \fi
  J\'a, n\'\i \v ze
  podepsan\JS@koncovka{\'y}{\'a}{\'y/\'a}
  student\JS@koncovka{}{ka}{(ka)}, t\'\i mto \v cestn\v e
  prohla\v suji, \v ze text mnou odevzdan\'e
  z\'av\v ere\v cn\'e pr\'ace v~p\'\i semn\'e podob\v e i na
  CD~nosi\v ci je toto\v zn\'y s~textem z\'av\v ere\v cn\'e
  pr\'ace vlo\v zen\'ym v~datab\'azi DIPL2.\par Prohla\v suji,
  \v ze p\v redlo\v zen\'a pr\'ace je m\'ym p\r
  uvodn\'\i m autorsk\'ym d\'\i lem, kter\'e jsem
  vypracoval\JS@koncovka{}{a}{(a)} samostatn\v e. Ve\v skerou
  literaturu a dal\v s\'\i\ zdroje, z~nich\v z jsem p\v ri
  zpracov\'an\'\i\ \v cerpal\JS@koncovka{}{a}{(a)}, v~pr\'aci
  \v r\'adn\v e cituji a jsou uvedeny v~seznamu pou\v zit\'e
  literatury.}
\def\JS@klicovaslova#1#2{\bigskip
  \begingroup
  \setbox1=\hbox{\bf#1:\quad}
  \adef,{,\penalty-1\ \ignorespaces}
  \hangindent\wd1 \hangafter1 \rightskip0pt plus1fil
  \linepenalty2
  \noindent\box1 #2\par
  \endgroup}
\def\JS@autorvedouci#1#2#3#4{{\large\sc
  \ea\def\ea\JS@AVvedouci\ea{#4}
  \setbox0=\hbox{#1:}\dimen0=\wd0
  \ifx\JS@AVvedouci\@empty
    \wd0=0pt
  \else
    \setbox0=\hbox{#3:}
  \fi
  \ifdim\dimen0<\wd0 \dimen0=\wd0 \fi
  \setbox0=\hbox{\hbox to\dimen0{\hss} #2}
  \dimen2=\wd0
  \setbox0=\hbox{\hbox to\dimen0{\hss} #4}
  \ifnum\dimen2<\wd0 \dimen2=\wd0 \fi
  \ifdim\dimen2>\hsize
    \noindent#1:\par
    \noindent\hskip2em
      \dimen4\hsize \advance\dimen4-2em
      \leftbox\dimen4{#2}\par
    \ifx\JS@AVvedouci\@empty\else
      \smallskip
      \noindent#3:\par
      \noindent\hskip2em
        \dimen4\hsize \advance\dimen4-2em
        \leftbox\dimen4{#4}\par
    \fi
  \else
    \leftline{\hbox to\dimen0{#1:\hfil} #2}
    \ifx\JS@AVvedouci\@empty\else
      \smallskip
      \leftline{\hbox to\dimen0{#3:\hfil} #4}
    \fi
  \fi}}
\def\cisloprvnistrany#1{\def\cisloprvnistrany@{#1}}
\univerzita{Ostravsk\'a univerzita\ifJS@MMXVII
  \else\space v~Ostrav\v e\fi}{University of Ostrava}
\podekovani{}
\nadpisabstraktu{Abstrakt}{Abstract}
\nadpisklicovychslov{Kl\'\i\v cov\'a slova}{Key Words}
\nadpisresume{Resum\'e}{Summary}
\nadpisautora{Autor pr\'ace}{Author}
\nadpisvedouciho{Vedouc\'\i\ pr\'ace}{Supervisor}
\def\JS@novyhook#1 {\@namedef{JS@hook#1}{}%
  \@namedef{hook#1}##1{\global\ea\OP@addto
    \csname JS@hook#1\endcsname{##1}}}
\JS@novyhook I
\JS@novyhook II
\JS@novyhook III
\JS@novyhook IV
\JS@novyhook V
\JS@novyhook VI
\newcount\JS@pocetzadani
\def\zadani#1#{\global\advance\JS@pocetzadani1
  \zadani@A{#1}}
\def\zadani@A#1#2{\hookVI{\JS@pagefig{#1}{#2}}}
\def\JS@pagefig#1#2{\clearpage
  \def\JS@pfa{#2}
  \ifx\JS@pfa\@empty
    \shipout\null
  \else
    {\pdfhorigin0pt \pdfvorigin0pt \hoffset0pt \voffset0pt
    \openin\testin=#2
    \ifeof\testin
      \shipout\vbox to\pdfpageheight{\vss
        \hbox to\pdfpagewidth{\hss
          Soubor {\tt#2} neexistuje!\hss}\vss}
     \errmessage{Soubor #2 se zadanim prace neexistuje}
    \else
      \closein\testin
      \pdfximage width\pdfpagewidth height\pdfpageheight #1 {#2}
      \shipout\hbox{\pdfrefximage\pdflastximage}
    \fi}
  \fi}
\ifLaTeX
  \RequirePackage{fancyhdr}
\fi
\ifPlain
  \def\nastav@zahlavi{
    \footline{\tenrm\thefontsize[12]%
      \hfil\the\pageno
      \ifJS@oneside\else
        \ifodd\pageno\else
          \hfill
        \fi
      \fi}}
\else
  \def\nastav@zahlavi{\pagestyle{fancy}\fancyhead{}\fancyfoot{}
    \headheight=14pt
    \renewcommand{\headrulewidth}{0pt}
    \renewcommand{\footrulewidth}{0pt}
    \ifJS@oneside
      \fancyfoot[R]{\thepage}
    \else
      \fancyfoot[LE,RO]{\thepage}
    \fi}
\fi
\def\strana@I{\JS@hookI
  \JS@begincenter
    \Large\bf\JS@strut\JS@uppercase\univerzita@CZ
  \JS@endcenter
  \vskip0pt plus0.618fill
  \JS@begincenter
    \huge\bf\JS@uppercase\typprace@CZ
  \JS@endcenter
  \vskip0pt plus 1fill
  {\Large\bf
  \setbox0=\hbox{\rok@\quad\JS@uppercase\autor@}
  \ifdim\wd0<\hsize
    \hbox to\hsize{\rok@\hfill\JS@uppercase\autor@}
  \else
    \centerbox\hsize{\JS@uppercase\autor@}
    \vskip6mm
    \centerline{\rok@}
  \fi}}
\def\strana@II{\JS@hookII
  \JS@cleardoublepage
  \JS@begincenter
    \Large\sc\JS@strut\JS@uppercase\univerzita@CZ
  \JS@endcenter
  \smallskip
  \JS@begincenter
    \Large\sc\JS@strut\JS@uppercase\fakulta@CZ
  \JS@endcenter
  \bigskip
  \JS@begincenter
    \large\sc\JS@strut\JS@uppercase\katedra@CZ
  \JS@endcenter
  \vskip0pt plus 0.5fill
  \JS@begincenter\huge\sc\nazev@CZ\JS@endcenter
  \vskip2mm
  \JS@begincenter
    \large\sc\typprace@CZ
  \JS@endcenter
  \vskip0pt plus 1fill
  \JS@autorvedouci\nadpisautora@CZ\autor@
    \nadpisvedouciho@CZ\vedouci@
  \vskip6mm
  \centerline{\large\sc\rok@}}
\def\strana@III{\JS@hookIII
  \JS@cleardoublepage
  \JS@begincenter
    \Large\sc\JS@strut\JS@uppercase\univerzita@EN
  \JS@endcenter
  \smallskip
  \JS@begincenter
    \Large\sc\JS@strut\JS@uppercase\fakulta@EN
  \JS@endcenter
  \bigskip
  \JS@begincenter
    \large\sc\JS@strut\JS@uppercase\katedra@EN
  \JS@endcenter
  \vskip0pt plus 0.5fill
  \JS@begincenter\huge\sc\nazev@EN\JS@endcenter
  \vskip2mm
  \JS@begincenter
    \large\sc\typprace@EN
  \JS@endcenter
  \vskip0pt plus 1fill
  \JS@autorvedouci\nadpisautora@EN\autor@
    \nadpisvedouciho@EN\vedouci@
  \vskip6mm
  \centerline{\large\sc\rok@}}
\def\strana@IV{\JS@hookIV
  \clearpage
  \ifx\podekovani@\long@empty
    \ifJS@oneside\else
      \hbox{}%
      \vfill
    \fi
  \else
    \ifPlain
      \vglue0ptplus1fill\relax
    \else
      \vspace*{\fill}
    \fi
    {\noindent\podekovani@\par}
  \fi}
\def\strana@V{\JS@hookV
  \clearpage
  \ifPlain
    \vglue0ptplus1fill\relax
  \else
    \vspace*{\fill}
  \fi
  {\noindent\JS@textprohlaseni\par
  \vskip10mm
  \noindent\JS@datumprohlaseni\hfill
  \hbox to 4cm{\dotfill}\par
  \rightline{\hbox to 4cm{\hss podpis\hss}}}}
\def\strana@VI{\JS@hookVI
  \clearpage
  {\ifPlain
    \JS@prvnijazyk
    \nonum\notoc\secc\nadpisabstraktu@CZ\par
  \else
    \ea\selectlanguage\ea{\JS@prvnijazyk}
    \subsection*{\nadpisabstraktu@CZ}
  \fi
  \abstrakt@CZ\par}
  \JS@klicovaslova\nadpisklicovychslov@CZ\klicovaslova@CZ
  {\ifPlain
    \JS@druhyjazyk
    \nonum\notoc\secc\nadpisabstraktu@EN\par
  \else
    \ea\selectlanguage\ea{\JS@druhyjazyk}
    \subsection*{\nadpisabstraktu@EN}
  \fi
  \abstrakt@EN\par}
  \JS@klicovaslova\nadpisklicovychslov@EN\klicovaslova@EN}
\def\JS@pocatecnistrany{\ifPlain\pageno-1 
  \else
    \setcounter{page}{-9}
  \fi
  \begingroup
  \JS@pagestyleempty
  \ifJS@old
    \strana@I
    \strana@II
    \strana@III
    \strana@IV
    \strana@V
    \strana@VI
  \else
    \strana@I
    \strana@II
    \strana@III
    \strana@VI
    \strana@V
    \strana@IV
  \fi
  \clearpage
  \endgroup
  \nastav@zahlavi
  \ifx\cisloprvnistrany@\undefined
    {\count0=\ifJS@oneside\ifx\podekovani@\long@empty
      5 \else 6 \fi\else 7 \fi
    \advance\count0 \JS@pocetzadani
    \ea}\ea\cisloprvnistrany\ea{\the\count0}
  \fi
  \ifPlain
    \pageno\cisloprvnistrany@
    \nonum\notoc\sec\mtext{toc}\par
    \maketoc
    \clearpage
  \else
    \ea\selectlanguage\ea{\JS@hlavnijazyk}
    \setcounter{page}{\cisloprvnistrany@}
    \tableofcontents
  \fi}
\ifPlain
  \def\pocatecnistrany{\ABDqueue
    \JS@pocatecnistrany}
\fi
\def\stranyresume{\clearpage
  {\ifPlain
    \JS@prvnijazyk
    \nonum\sec\nadpisresume@CZ\par
  \else
    \ea\selectlanguage\ea{\JS@prvnijazyk}
    \section*{\nadpisresume@CZ}%
    \addcontentsline{toc}{section}{\nadpisresume@CZ}
  \fi
  \resume@CZ\par}
  \clearpage
  {\ifPlain
    \JS@druhyjazyk
    \nonum\sec\nadpisresume@EN\par
  \else
    \ea\selectlanguage\ea{\JS@druhyjazyk}
    \section*{\nadpisresume@EN}
    \addcontentsline{toc}{section}{\nadpisresume@EN}
  \fi
  \resume@EN\par}}
\ifPlain
  \def\jazyky#1#2{\JS@pouzito{jazyky}
    \def\JS@prvnijazyk{#1}
    \def\JS@druhyjazyk{#2}}
  \def\hlavnijazyk{\JS@pouzito{hlavnijazyk}}
\else
  \def\jazyky{\JS@pouzito{jazyky}
    \@ifnextchar[\JS@jazykyB\JS@jazykyA}
  \def\JS@jazykyA{\JS@jazykyB[]}
  \def\JS@jazykyB[#1]#2#3{\def\JS@prvnijazyk{#2}
    \def\JS@druhyjazyk{#3}
    \def\JS@dalsijazyky{#1}
    \ifx\JS@dalsijazyky\@empty\else
      \def\JS@dalsijazyky{#1,}
    \fi
    \usepackage[\JS@dalsijazyky\JS@druhyjazyk,\JS@prvnijazyk]
      {babel}}
  \def\hlavnijazyk#1{\JS@pouzito{hlavnijazyk}
    \def\JS@hlavnijazyk{#1}
    \AtBeginDocument{\selectlanguage{#1}}}
\fi
\JS@inpreamble{jazyky}
\JS@inpreamble{hlavnijazyk}
\ifPlain
  \ifx\cslang\undefined \let\cslang\czlang \fi
\fi
\ifPlain
  \sdef{mt:toc:en}{Contents}
  \sdef{mt:toc:cs}{Obsah}
  \sdef{mt:toc:sk}{Obsah}
\fi
\ifPlain
  \openin\testin=pdfuni.tex
  \ifeof\testin
    \let\pdfunidef\def
  \else
    \closein\testin
    \input pdfuni.tex
  \fi
  \AtBeginDocument{
    \pdfunidef\tmp{\autor@} \pdfinfo{/Author (\tmp)}
    \pdfunidef\tmp{\nazev@CZ} \pdfinfo{/Title (\tmp)}
    \pdfunidef\tmp{\typprace@CZ} \pdfinfo{/Subject (\tmp)}
    {\adef,{, \@firstofone}
      \pdfunidef\tmp{\klicovaslova@CZ\long@empty}%
      \pdfinfo{/Keywords (\tmp)}}}
\else
  \AtBeginDocument{\hypersetup{
      pdfauthor={\autor@},
      pdftitle={\nazev@CZ},
      pdfsubject={\typprace@CZ}}
    {\adef,{, \@firstofone}
      \hypersetup{pdfkeywords={\klicovaslova@CZ\long@empty}}}}
\fi
\ifLaTeX
  \AtBeginDocument{\let\default@color\current@color}
  \AtBeginDocument{\JS@pocatecnistrany}
\fi
\ifPlain
  \let\OP@sec\sec
  \def\sec{\ifJS@samepage\else\JS@clearpage\fi\OP@sec}
\else
  \AtBeginDocument{\JS@formatsekci}
  \def\JS@formatsekci{%
    \renewcommand\section{\ifJS@samepage\else\JS@clearpage\fi
      \@startsection {section}{1}{\z@}%
        {-3.5ex \@plus -1ex \@minus -.2ex}%
        {2.3ex \@plus.2ex}%
        {\normalfont\Large\bfseries\mathversion{bold}}}
    \renewcommand\subsection{%
      \@startsection{subsection}{2}{\z@}%
        {-3.25ex\@plus -1ex \@minus -.2ex}%
        {1.5ex \@plus .2ex}%
        {\normalfont\large\bfseries\mathversion{bold}}}
    \renewcommand\subsubsection{%
      \@startsection{subsubsection}{3}{\z@}%
        {-3.25ex\@plus -1ex \@minus -.2ex}%
        {1.5ex \@plus .2ex}%
        {\normalfont\normalsize\bfseries\mathversion{bold}}}
    \renewcommand\paragraph{%
      \@startsection{paragraph}{4}{\z@}%
        {3.25ex \@plus1ex \@minus.2ex}%
        {-1em}%
        {\normalfont\normalsize\bfseries\mathversion{bold}}}
    \renewcommand\subparagraph{%
      \@startsection{subparagraph}{5}{\parindent}%
        {3.25ex \@plus1ex \@minus .2ex}%
        {-1em}%
        {\normalfont\normalsize\bfseries\mathversion{bold}}}}
\fi
\def\JS@cleardoublepage{\clearpage
  \ifodd\count0 \else \ifJS@oneside \else
    \begingroup\JS@pagestyleempty
      \null\clearpage\endgroup\fi\fi}
\let\cleardoublepage\JS@cleardoublepage
\ifPlain
  \def\tocline#1#2#3#4#5{{\leftskip=#1\iindent
  \rightskip=2\iindent
  \toclinehook
  \ifnum#1<2
    \bigskip\bfshape \let\tocdotfill\hfill
  \else
    \rm
  \fi
  \noindent\llap{\toclink{#3}\enspace}%
    {#4\unskip}\nobreak\tocdotfill\pglink{#5}\nobreak
    \hskip-2\iindent\null\par}}
\else
  \renewcommand*\l@section[2]{%
    \ifnum \c@tocdepth >\z@
      \addpenalty\@secpenalty
      \addvspace{1.0em \@plus\p@}%
      \setlength\@tempdima{1.5em}%
      \begingroup
        \parindent \z@ \rightskip \@pnumwidth
        \parfillskip -\@pnumwidth
        \leavevmode \bfseries \mathversion{bold}%
        \advance\leftskip\@tempdima
        \hskip -\leftskip
        #1\nobreak\hfil \nobreak\hb@xt@\@pnumwidth{\hss #2}\par
      \endgroup
    \fi}
\fi
\def\JS@ISBNpenalty{2000 }
\def\ISBN#1{ISBN\penalty\JS@ISBNpenalty\space\hbox{#1}}
\def\ISSN#1{ISSN\penalty\JS@ISBNpenalty\space\hbox{#1}}
\ifPlain
  \catcode`\@=12
\fi
\endinput
%This document class is free software: you can redistribute it
%and/or modify it under the terms of the GNU General Public
%License as published by the Free Software Foundation, either
%version~3 of the License, or (at your option) any later version.
%
%This document class is distributed in the hope that it will
%be useful, but WITHOUT ANY WARRANTY; without even the implied
%warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR
%PURPOSE. See the GNU General Public License for more details,
%{\tt<http://www.gnu.org/licenses/>}.
%
%Created by Jan Šustek in 2009, 2010, 2012, 2013, 2015.

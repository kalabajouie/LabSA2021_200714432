ó
jD:\Documents\GitHub\LabSA2021_200714432\ServicioRestaurante\ServicioRestaurante\My Project\AssemblyInfo.vb
<

 
Assembly

 	
:

	 

AssemblyTitle

 
(

 
$str

 .
)

. /
>

/ 0
< 
Assembly 	
:	 

AssemblyDescription 
( 
$str !
)! "
>" #
< 
Assembly 	
:	 

AssemblyCompany 
( 
$str 
) 
> 
< 
Assembly 	
:	 

AssemblyProduct 
( 
$str 0
)0 1
>1 2
< 
Assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
>1 2
< 
Assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
>  !
< 
Assembly 	
:	 


ComVisible 
( 
False 
) 
> 
< 
Assembly 	
:	 

Guid 
( 
$str 6
)6 7
>7 8
<!! 
Assembly!! 	
:!!	 

AssemblyVersion!! 
(!! 
$str!! $
)!!$ %
>!!% &
<"" 
Assembly"" 	
:""	 

AssemblyFileVersion"" 
("" 
$str"" (
)""( )
>"") *—:
yD:\Documents\GitHub\LabSA2021_200714432\ServicioRestaurante\ServicioRestaurante\My Project\MyExtensions\MyWebExtension.vb
	Namespace 	
My
 
< 
Global 
. 
	Microsoft 
. 
VisualBasic !
.! "
HideModuleName" 0
(0 1
)1 2
>2 3
Module		 

MyWebExtension		 
Private

 
ReadOnly

 

s_Computer

 #
As

$ &
New

' *$
ThreadSafeObjectProvider

+ C
(

C D
Of

D F
Global

G M
.

M N
	Microsoft

N W
.

W X
VisualBasic

X c
.

c d
Devices

d k
.

k l
ServerComputer

l z
)

z {
Private 
ReadOnly 
s_User 
As  "
New# &$
ThreadSafeObjectProvider' ?
(? @
Of@ B
GlobalC I
.I J
	MicrosoftJ S
.S T
VisualBasicT _
._ `
ApplicationServices` s
.s t
WebUsert {
){ |
Private 
ReadOnly 
s_Log 
As !
New" %$
ThreadSafeObjectProvider& >
(> ?
Of? A
GlobalB H
.H I
	MicrosoftI R
.R S
VisualBasicS ^
.^ _
Logging_ f
.f g
AspLogg m
)m n
< 	
Global	 
. 
System 
. 
Diagnostics "
." #
CodeAnalysis# /
./ 0$
SuppressMessageAttribute0 H
(H I
$strI `
,` a
$str	b ƒ
)
ƒ „
>
„ …
Friend 
ReadOnly 
Property  
Computer! )
() *
)* +
As, .
Global/ 5
.5 6
	Microsoft6 ?
.? @
VisualBasic@ K
.K L
DevicesL S
.S T
ServerComputerT b
Get 
Return 

s_Computer !
.! "
GetInstance" -
(- .
). /
End 
Get 
End 
Property 
< 	
Global	 
. 
System 
. 
Diagnostics "
." #
CodeAnalysis# /
./ 0$
SuppressMessageAttribute0 H
(H I
$strI `
,` a
$str	b ƒ
)
ƒ „
>
„ …
Friend 
ReadOnly 
Property  
User! %
(% &
)& '
As( *
Global+ 1
.1 2
	Microsoft2 ;
.; <
VisualBasic< G
.G H
ApplicationServicesH [
.[ \
WebUser\ c
Get 
Return 
s_User 
. 
GetInstance )
() *
)* +
End 
Get 
End 
Property 
<"" 	
Global""	 
."" 
System"" 
."" 
Diagnostics"" "
.""" #
CodeAnalysis""# /
.""/ 0$
SuppressMessageAttribute""0 H
(""H I
$str""I `
,""` a
$str	""b ƒ
)
""ƒ „
>
""„ …
<## 	
Global##	 
.## 
System## 
.## 
ComponentModel## %
.##% &
Design##& ,
.##, -
HelpKeyword##- 8
(##8 9
$str##9 E
)##E F
>##F G
Friend$$ 
ReadOnly$$ 
Property$$  
Request$$! (
($$( )
)$$) *
As$$+ -
Global$$. 4
.$$4 5
System$$5 ;
.$$; <
Web$$< ?
.$$? @
HttpRequest$$@ K
<%% 
Global%% 
.%% 
System%% 
.%% 
Diagnostics%% &
.%%& '
DebuggerHidden%%' 5
(%%5 6
)%%6 7
>%%7 8
Get&& 
Dim'' 
CurrentContext'' "
As''# %
Global''& ,
.'', -
System''- 3
.''3 4
Web''4 7
.''7 8
HttpContext''8 C
=''D E
Global''F L
.''L M
System''M S
.''S T
Web''T W
.''W X
HttpContext''X c
.''c d
Current''d k
If(( 
CurrentContext(( !
IsNot((" '
Nothing((( /
Then((0 4
Return)) 
CurrentContext)) )
.))) *
Request))* 1
End** 
If** 
Return++ 
Nothing++ 
End,, 
Get,, 
End-- 
Property-- 
<11 	
Global11	 
.11 
System11 
.11 
Diagnostics11 "
.11" #
CodeAnalysis11# /
.11/ 0$
SuppressMessageAttribute110 H
(11H I
$str11I `
,11` a
$str	11b ƒ
)
11ƒ „
>
11„ …
<22	 

Global22
 
.22 
System22 
.22 
ComponentModel22 &
.22& '
Design22' -
.22- .
HelpKeyword22. 9
(229 :
$str22: G
)22G H
>22H I
Friend33	 
ReadOnly33 
Property33 !
Response33" *
(33* +
)33+ ,
As33- /
Global330 6
.336 7
System337 =
.33= >
Web33> A
.33A B
HttpResponse33B N
<44 
Global44 
.44 
System44 
.44 
Diagnostics44 &
.44& '
DebuggerHidden44' 5
(445 6
)446 7
>447 8
Get55 
Dim66 
CurrentContext66 "
As66# %
Global66& ,
.66, -
System66- 3
.663 4
Web664 7
.667 8
HttpContext668 C
=66D E
Global66F L
.66L M
System66M S
.66S T
Web66T W
.66W X
HttpContext66X c
.66c d
Current66d k
If77 
CurrentContext77 !
IsNot77" '
Nothing77( /
Then770 4
Return88 
CurrentContext88 )
.88) *
Response88* 2
End99 
If99 
Return:: 
Nothing:: 
End;; 
Get;; 
End<< 
Property<< 
<@@ 	
Global@@	 
.@@ 
System@@ 
.@@ 
Diagnostics@@ "
.@@" #
CodeAnalysis@@# /
.@@/ 0$
SuppressMessageAttribute@@0 H
(@@H I
$str@@I `
,@@` a
$str	@@b ƒ
)
@@ƒ „
>
@@„ …
FriendAA 
ReadOnlyAA 
PropertyAA  
LogAA! $
(AA$ %
)AA% &
AsAA' )
GlobalAA* 0
.AA0 1
	MicrosoftAA1 :
.AA: ;
VisualBasicAA; F
.AAF G
LoggingAAG N
.AAN O
AspLogAAO U
GetBB 
ReturnCC 
s_LogCC 
.CC 
GetInstanceCC (
(CC( )
)CC) *
EndDD 
GetDD 
EndEE 
PropertyEE 
EndFF 
ModuleFF	 
EndGG 
	NamespaceGG ³*
cD:\Documents\GitHub\LabSA2021_200714432\ServicioRestaurante\ServicioRestaurante\Restaurante.asmx.vb
< 
System 
. 
Web 
. 
Services 
. 

WebService 
(  
	Namespace  )
:=) +
$str+ @
)@ A
>A B
< 
System 
. 
Web 
. 
Services 
. 
WebServiceBinding &
(& '

ConformsTo' 1
:=1 3
WsiProfiles3 >
.> ?
BasicProfile1_1? N
)N O
>O P
<		 
ToolboxItem		 
(		 
False		 
)		 
>		 
Public

 
Class

 
Restaurante

 
Inherits 
System 
. 
Web 
. 
Services  
.  !

WebService! +
Shared 

colaPedidos 
As 
New 
Queue #
Shared 

colaPedidosListos 
As 
New  #
Queue$ )
Shared 
!
colaPedidosRepartidor  
As! #
New$ '
Queue( -
Shared 

idPedido 
As 
Integer 
< 
	WebMethod 
( 
) 
> 
Public 

Function  
RecibirPedidoCliente (
(( )
descripcion_pedido) ;
As< >
String? E
)E F
AsG I
StringJ P
idPedido 
= 
idPedido 
+ 
$num 
Dim 
clave_valor 
As 
New 
KeyValuePair +
(+ ,
Of, .
Integer/ 6
,6 7
String8 >
)> ?
(? @
idPedido@ H
,H I
descripcion_pedidoJ \
)\ ]
colaPedidos 
. 
Enqueue 
( 
clave_valor '
)' (
Return 
$str +
&, -
descripcion_pedido. @
&A B
$strC ]
&^ _
idPedido` h
End 
Function 
< 
	WebMethod 
( 
) 
> 
Public 

Function 
EstadoPedidoCliente '
(' (
idpedido( 0
As1 3
Integer4 ;
); <
As= ?
String@ F
Dim 
a 
As 
New 
KeyValuePair !
(! "
Of" $
Integer% ,
,, -
String. 4
)4 5
(5 6
)6 7
Dim   
	respuesta   
As   
String   
=    !
$str  " $
For$$ 
Each$$ 
elemento$$ 
In$$ 
colaPedidos$$ (
a%% 
=%% 
elemento%% 
If&& 
a&& 
.&& 
Key&& 
=&& 
idpedido&& 
Then&&  $
	respuesta'' 
='' 
$str'' )
&''* +
a'', -
.''- .
Value''. 3
&''4 5
$str''6 M
End(( 
If(( 
Next)) 
For,, 
Each,, 
elemento,, 
In,, 
colaPedidosListos,, .
a-- 
=-- 
elemento-- 
If.. 
a.. 
... 
Key.. 
=.. 
idpedido.. 
Then..  $
	respuesta// 
=// 
$str// )
&//* +
a//, -
.//- .
Value//. 3
&//4 5
$str//6 W
End00 
If00 
Next11 
If44 

	respuesta44 
=44 
$str44 
Then44 
	respuesta55 
=55 
$str55 $
&55% &
idpedido55' /
&550 1
$str552 X
End66 
If66 
If:: 

colaPedidos:: 
.:: 
Count:: 
>:: 
$num::  
Then::! %
colaPedidosListos;; 
.;; 
Enqueue;; %
(;;% &
colaPedidos;;& 1
.;;1 2
Peek;;2 6
(;;6 7
);;7 8
);;8 9
colaPedidos<< 
.<< 
Dequeue<< 
(<<  
)<<  !
End== 
If== 
Return?? 
	respuesta?? 
EndAA 
FunctionAA 
<CC 
	WebMethodCC 
(CC 
)CC 
>CC 
PublicDD 

FunctionDD !
PedidoListoRepartidorDD )
(DD) *
idpedidoDD* 2
AsDD3 5
IntegerDD6 =
,DD= >
nombre_repartidorDD? P
AsDDQ S
StringDDT Z
)DDZ [
AsDD\ ^
StringDD_ e
DimEE 
ESBEE 
AsEE 
NewEE 
WSESBEE 
.EE 
ESBSoapClientEE *
ReturnGG 
ESBGG 
.GG !
PedidoListoRepartidorGG (
(GG( )
idpedidoGG) 1
,GG1 2
nombre_repartidorGG3 D
)GGD E
EndHH 
FunctionHH 
EndLL 
ClassLL 	
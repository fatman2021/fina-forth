: .line type cr ;
: license
   s" LICENSE" r/o open-file throw >r
   r@ ['] .line foreachline
   r> close-file throw ;

:noname
   ." FINA v0.2. Copyright (c) 2004-2007, Jorge Acereda Macia." cr
   ." FINA comes with EVEN LESS WARRANTY; for details type 'license'." cr
   ." Type 'bye' to exit." cr
; is banner

: doargs
   #args 1 ?do
      0
      i arg drop c@ [char] - = if
         i arg s" -e" compare 0= if  i swap >r 1+ arg evaluate  r> 2 +  then
         i arg s" -s" compare 0= if  ['] noop is banner 1+  then
         dup 0= if i arg type ."  ignored" cr 1+ then
      else i swap >r arg included r> 1+ then
   +loop ;

:noname
   ['] doargs catch .error
   deferred coldchain ; is coldchain

:noname
   ." ok" cr ; '.prompt ! 
echo on 

row = 0
num = 0;
color = 0;
for i in range( 64 ):
    if( num%8 == 0 ):
        row = ~row
        print("\n")

    color = ( row & 1 ) ^ (num & 1 );
    print( color )
        

class ArrayDemo{




/* 1 2 3 4 5 => 5 4 3 2 1

5

1 => 15
2=> 24

if(i!=(n-1-i)) 
temp = a[i]
a[i] = a[n-1-i]
a[n-1-i] =  temp;

*/

	static void reverseArray(int[] arr, int n)
	{
		int temp;
		
		for(int i=0;i<n;i++){
			
			if(i==(n-1-i))
			break;
		
			temp = arr[i];
			arr[i] = arr[n-1-i];
			arr[n-1-i] =  temp;
		}
		
	}
	
	public static void main(String... args){

	int[] arr={1,2,3,4,5};
	
	int n = arr.length;
	
	reverseArray(arr, n);	
	
		for(int y : arr)
		{
			System.out.print(y +" => ");
		}
	}	

}
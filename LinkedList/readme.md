                               DOCUMENTATION
 
1. In this libarary Singly and Double linked list was implemented
 
 2. In order to do instance (SinglyLinkedList or DoubleLinkedList) you should indicate generic (type) which 
      will used for saving values
	  For example:
	  
	         var slink = new SinglyLinkedList<string>();
		 var dlink = new DoubleLinkedList<string>();
 
 
2. Using this Linked list you can use several  Methods :

    a.  Method Add(T value) - adding new object Node to linked list with value
  
  	        slink.Add("Piter");
            slink.Add("Mike");
            slink.Add("Anna")
			
			you can chech Add method when using  this code			
			foreach (var item in link1)
			....
			Piter
			Mike
			Anna
  
    b.  Method Contains(T value) - checking  whether list have the value?
  
           for checking single linked list:
           SinglyNode<string> slink1 = sLink.Contains("Piter");
           SinglyNode<string> slink2 = sLink.Contains("Anna");
		   		   
		   slink1.Value == "Piter";
           slink2.Value == "Anna";
		   slink1.Next == link2
		   
		   for checking double linked list:
		   
		   DoubleNode<string> dlink1 = dLink.Contains("Piter");
           DoubleNode<string> dlink2 = dLink.Contains("Anna");
		   		   
		   dlink1.Value == "Piter";
           dlink2.Value == "Anna";
		   dlink1.Next == ldink2
		   ldink2.Prev = dlink1;
  
    c.  Method Remove(T Value)  - removing  Node from Linked list according to the specific value
           
		   slink1.Remove("Piter")
		   dlink1.Remove("Piter")
		   Realized (Single and Double) Linked list is different
		   SingleLinkedList class - one-way links
		   DoubleLinkedList class - two way links
      
    d.  Method ValueArray()   - returning Array of value of Linked list	

            slink.Add("Piter");
            slink.Add("Mike");
            slink.Add("Anna");
	    String.Join(" , ", link1.ValueArray())  
		  
		  you can watch such result when outputing to the console
		  
		  Piter, Mike, Anna
  
  I.   In this Library  was implemented interface IEnumerable
       It can give you possibilty to iterate Linked list using loop as foreach
  
  II.  Also  "test cases" was implemented
  
  III.  All classes in this library is sealed so you can not override or inherit it.

	  
	   
			
	  

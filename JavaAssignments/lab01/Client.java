import java.util.Scanner;

public class Client extends Contact
{
    

    public static void main(String[] args) 
    {
        Friend friend1 = new Friend();
        Friend friend2 = new Friend();
        Friend friend3 = new Friend();
        Business business1 = new Business();
        Business business2 = new Business();
        Business business3 = new Business();
        
        Scanner scan = new Scanner (System.in);
        
        //I realize that the following blocks of code could be better utilized through loops.
        //The following code asks for user input, then uses the input to set the Object parameters.
        
        System.out.println("Please enter a Friend's name: ");
        String myFriendName = scan.nextLine();
        System.out.println("Please enter a Friend's Address: ");
        String myFriendAddress = scan.nextLine();
        System.out.println("Please enter a Friend's birthday (MM/DD/YYYY): ");
        String myFriendBirthday = scan.nextLine();
        System.out.println("Please enter a Friend's favorite movie: ");
        String myFriendFavoriteMovie = scan.nextLine();
        System.out.println("Please enter a Friend's phone number: ");
        int myFriendPhone = scan.nextInt();
        
        friend1.setName(myFriendName);
        friend1.setAddress(myFriendAddress);
        friend1.setPhone(myFriendPhone);
        friend1.setBirthday(myFriendBirthday);
        friend1.setFavoriteMovie(myFriendFavoriteMovie);
        
        System.out.println("Please enter a Friend's name: "); 
        myFriendName = scan.nextLine();
        System.out.println("Please enter a Friend's Address: ");
        myFriendAddress = scan.nextLine();
        System.out.println("Please enter a Friend's birthday (MM/DD/YYYY): ");
        myFriendBirthday = scan.nextLine();
        System.out.println("Please enter a Friend's favorite movie: ");
        myFriendFavoriteMovie = scan.nextLine();
        System.out.println("Please enter a Friend's phone number: ");
        myFriendPhone = scan.nextInt();
        
        friend2.setName(myFriendName);
        friend2.setAddress(myFriendAddress);
        friend2.setPhone(myFriendPhone);
        friend2.setBirthday(myFriendBirthday);
        friend2.setFavoriteMovie(myFriendFavoriteMovie);
        
        System.out.println("Please enter a Friend's name: "); 
        myFriendName = scan.nextLine();
        System.out.println("Please enter a Friend's Address: ");
        myFriendAddress = scan.nextLine();
        System.out.println("Please enter a Friend's birthday (MM/DD/YYYY): ");
        myFriendBirthday = scan.nextLine();
        System.out.println("Please enter a Friend's favorite movie: ");
        myFriendFavoriteMovie = scan.nextLine();
        System.out.println("Please enter a Friend's phone number: ");
        myFriendPhone = scan.nextInt();
        
        friend3.setName(myFriendName);
        friend3.setAddress(myFriendAddress);
        friend3.setPhone(myFriendPhone);
        friend3.setBirthday(myFriendBirthday);
        friend3.setFavoriteMovie(myFriendFavoriteMovie);
        
        //Friends end, Business begins.
        
        System.out.println("Please enter a Business Contact Name: ");
        String businessContactName = scan.nextLine();
        System.out.println("Please enter a Business Contact Address: ");
        String businessContactAddress = scan.nextLine();
        System.out.println("Please enter a Business Contact Phone: ");
        int businessContactPhone = scan.nextInt();
        System.out.println("Please enter a Business Contact Title: ");
        String businessContactTitle = scan.nextLine();
        System.out.println("Please enter a Business Contact Business Name: ");
        String businessContactBN = scan.nextLine();
        
        business1.setName(businessContactName);
        business1.setAddress(businessContactAddress);
        business1.setPhone(businessContactPhone);
        business1.setTitle(businessContactTitle);
        business1.setBusinessName(businessContactBN);
        
        System.out.println("Please enter a Business Contact Name: ");
        businessContactName = scan.nextLine();
        System.out.println("Please enter a Business Contact Address: ");
        businessContactAddress = scan.nextLine();
        System.out.println("Please enter a Business Contact Phone: ");
        businessContactPhone = scan.nextInt();
        System.out.println("Please enter a Business Contact Title: ");
        businessContactTitle = scan.nextLine();
        System.out.println("Please enter a Business Contact Business Name: ");
        businessContactBN = scan.nextLine();
        
        business2.setName(businessContactName);
        business2.setAddress(businessContactAddress);
        business2.setPhone(businessContactPhone);
        business2.setTitle(businessContactTitle);
        business2.setBusinessName(businessContactBN);
        
        System.out.println("Please enter a Business Contact Name: ");
        businessContactName = scan.nextLine();
        System.out.println("Please enter a Business Contact Address: ");
        businessContactAddress = scan.nextLine();
        System.out.println("Please enter a Business Contact Phone: ");
        businessContactPhone = scan.nextInt();
        System.out.println("Please enter a Business Contact Title: ");
        businessContactTitle = scan.nextLine();
        System.out.println("Please enter a Business Contact Business Name: ");
        businessContactBN = scan.nextLine();
        
        business3.setName(businessContactName);
        business3.setAddress(businessContactAddress);
        business3.setPhone(businessContactPhone);
        business3.setTitle(businessContactTitle);
        business3.setBusinessName(businessContactBN);
    
        Friend myFriend;
        Business newBusinessContact;
        
        //An array is created and the above Objects are added.
        
        Contact[] addressBook = new Contact[6];
        addressBook[0] = friend1;
        addressBook[1] = friend2;
        addressBook[2] = friend3;
        addressBook[3] = business1;
        addressBook[4] = business2;
        addressBook[5] = business3;
        
        //Following code outputs all contacts in addressBook array
        
        myFriend = (Friend) addressBook[0];
        
        System.out.println( "Friend 1: " + myFriend.getName() + "\n          " + myFriend.getAddress() 
                + "\n          " + myFriend.getPhone() + "\n          " + myFriend.getBirthday() 
                + "\n          " + myFriend.getFavoriteMovie() );
        
        myFriend = (Friend) addressBook[1];
        
        System.out.println( "Friend 2: " + myFriend.getName() + "\n          " + myFriend.getAddress() 
                + "\n          " + myFriend.getPhone() + "\n          " + myFriend.getBirthday() 
                + "\n          " + myFriend.getFavoriteMovie() );
        
        myFriend = (Friend) addressBook[2];
        
        System.out.println( "Friend 3: " + myFriend.getName() + "\n          " + myFriend.getAddress() 
                + "\n          " + myFriend.getPhone() + "\n          " + myFriend.getBirthday() 
                + "\n          " + myFriend.getFavoriteMovie() );
        
       
        newBusinessContact = (Business) addressBook[3];
        
        System.out.println( "Business 1: " + newBusinessContact.getName() + "\n            " + newBusinessContact.getAddress() 
                + "\n            " + newBusinessContact.getPhone() + "\n            " + newBusinessContact.getTitle() 
                + "\n            " + newBusinessContact.getBusinessName() );
        
        newBusinessContact = (Business) addressBook[4];
        
        System.out.println( "Business 2: " + newBusinessContact.getName() + "\n            " + newBusinessContact.getAddress() 
                + "\n            " + newBusinessContact.getPhone() + "\n            " + newBusinessContact.getTitle() 
                + "\n            " + newBusinessContact.getBusinessName() );
        
        newBusinessContact = (Business) addressBook[5];
        
        System.out.println( "Business 3: " + newBusinessContact.getName() + "\n            " + newBusinessContact.getAddress() 
                + "\n            " + newBusinessContact.getPhone() + "\n            " + newBusinessContact.getTitle() 
                + "\n            " + newBusinessContact.getBusinessName() );
        
        
        
        System.out.println("Number of Friends: " + Friend.getFriendCount());
        System.out.println("Number of Business Contacts: " + Business.getBusinessCount());
        System.out.println("Total Number of Contacts: " + Contact.getContactCount());

    }
}

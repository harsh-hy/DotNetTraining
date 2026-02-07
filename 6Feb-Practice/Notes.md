
------SQL------

increase the performance
--> get the page size
--> create the view (it removes unncecsssory options)
	> best practice : max now of views 4-6 for one table
	> can we create it dynamiically? 
    > what is pagination :
    > Create a serialNo Column
--> indexers 
--> cursor(dast forward read only)
    > row by row!
    > diff logic on diff rows 
    >! it needs to be closed and deallocated !!
    > it occupies the program memory !! so we have to close it!
    > transaction!! is used for atomicity!

----temperoary Table!

Smiple Caclculator:


![image](https://github.com/elad11310/SimpleCalculator/assets/57447475/7f69ef1f-45fc-4ddf-99ab-c084c0f886fa)



**Requirements:**    

1) Microsoft Visual Studio   
2) .NET 8   
3) Sql Server   
4) Asp.net core  

**Configurations:**  

1) For auto creating of the db and suitable tables:  
    a. Clone this project  
    b. In Package Manager Console type - EntityFrameworkCore\update-database  

**Capabilities:**   

This calculator can perform arithmetic actions and string actions.  
It has four actions by default (Addition,Substraction,Division,Multiplication)  

All the supported actions are :  

   Addition,  
   Subtraction,  
   Division,  
   Multiplication,  
   Power,  
   Modulus,  
   Compare,  
   Concatenate,  
   Contains,  
   Equals,  
   IndexOf  

In order to dynamically add/remove action without shuting down the application :  

In Actions table insert/remove a record like the following example :   

![image](https://github.com/elad11310/SimpleCalculator/assets/57447475/ca45026c-2cfc-4636-bdb9-5b95219f9da4)


**API refrences:**  

1) **/api/operations/GetAllOperations**  
   Type: GET  
   Description: Returns all operations.  
   
2) **/api/operations/GetHistoricData?operation="operation"**  
   Type: GET  
   Description: Gets historic data for a specific operation  

3) **/api/operations/Execute**  
   Type: POST  
   Description : Returns a result for action.  
   Body parameters example :  
     
   {  
   "OperandA": "5",  
   "operation": "Addition",  
   "OperandB": "6"  
   }  



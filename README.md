
![image](https://github.com/elad11310/SimpleCalculator/assets/57447475/7f69ef1f-45fc-4ddf-99ab-c084c0f886fa)



**Requirements:**    

1) Microsoft Visual Studio   
2) .NET 8   
3) Sql Server   
4) Asp.net core  

**Configurations:**  

1. Clone this project.  
2. Open Visual Studio and navigate to Tools > NuGet Package Manager > Package Manager Console.  
3. In the Package Manager Console, execute the command: `EntityFrameworkCore\update-database`.  


**Capabilities:**   

This calculator can perform arithmetic actions and string actions.  
It has four actions by default (Addition,Substraction,Division,Multiplication)  

All the supported actions are :  

   -Addition   
   -Subtraction    
   -Division    
   -Multiplication    
   -Power    
   -Modulus    
   -Compare    
   -Concatenate    
   -Contains    
   -Equals    
   -IndexOf    

**Adding/Removing Actions Dynamically:**  

To dynamically add or remove actions without shutting down the application:  

1. Use SQL commands to insert or remove a record in the `Actions` table.  
2. For example:  
   - To insert a new action: `INSERT INTO [Actions] VALUES ('Perform power', 'Power')`  
   - To remove an action: `DELETE FROM [Actions] WHERE Operation = 'Power'`  
3. After making changes, refresh the application's home page.  


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



# EntityFramework_CodeFirstApproach
This project contains .Net core project using Entity framework core with code first approach with basic Fluent API.

Solution contains two projects.

1. DAO_EFCORE.DAL - containing code first approach.
    
    KeepNoteContext.cs contains all model builder code to create database
    NoteRepository.cs contails all DML operation to add Note, Label, Checklist item for Note. Also contains update and get methods.
    
2. DAO_EFCORE.DAL.Tests: Test project 
  
    It will create the in memory database using context and test all the repository functions.

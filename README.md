# PetStoreAPI

## Project Solution
This solution is divided into two projects (PetStoreAPI) where the Controller(Client Rest and Rest Request), Model(Objects), Resources (files to test the uplad file on the endpoints) and Service (Interfaces and Service Class), and a class of test (PetStoreAPITests) where the test to be performed in this project is located.

## Scenarios covered on the solution:

## Pet (PetControllerTest.cs)
Verify images can be uploaded to pet.
UploadImageToAPetByID_ReturnTrue

Verify pets can be search by ID.
GetPetByID_ReturnTrueIfFound

Verify pets can be search by nonexistent ID .
GetPetByID_ReturnTrueIfNotFound

Verify pets can be search by status(available,pending and sold).
GetPetByStatus_ReturnTrueIfExistPetByStatus

Verify pets can be search by nonexistent status(none).
GetPetByStatus_ReturnTrueIfNotExistPetByStatus

Verify pets can be created by Pet Object.
Post_ReturnTrueIfCreateNewPet

Verify pets can be Updated by status(available).
Put_ReturnTrueIfUpdatePet

Verify pets can be Deleted by ID.
Delete_ReturnTrueIfDeletePet

Verify pets can be Deleted by nonexistent ID.
Delete_ReturnTrueIfDeletePetNotFound


## Store (StoreControllerTest.cs)

Verify Order can be search by Id.
GetByID_ReturnTrueIfFound

Verify Order can be search by nonexistent Id.
GetByID_ReturnTrueIfNotFound

Verify Order can be Deleted by ID.
Delete_ReturnTrueIfFound

Verify Order can be Deleted by nonexistent ID.
Delete_ReturnTrueIfNotFound

Verify all Status existentes. 
GetAllStatus_ReturnTrueIfFound

Verify Order can be created for a Pet.
Post_ReturnTrueIfCreateNewOrderForAPet

## User(UserControllerTest.cs)

Verify if a list of Users can be created by array.
Post_ReturnTrueIfCreateListOfUserArray 

Verify if a list of Users can be created by a list.
Post_ReturnTrueIfCreateListOfUser 

Verify Users can search by user name.
GetByUserName_ReturnTrueIfFound 

Verify Users can be Deleted by user name.
Delete_ReturnTrueIfFound

Verify Users can be Updated by user.
Put_ReturnTrueIfUpdateUser 

Verify Users can be Deleted by nonexistent user name (Cookie).
Delete_ReturnTrueIfNotFound

Verify Users can be Deleted by null user name.
Delete_ReturnTrueIfMethodNotAllowed 

Verify Users can logIn/logOut.
GetByUserNameAndPasswordAndGetByUserLogout_ReturnTrueIfFound 

Verify if Users can be created.
Post_ReturnTrueIfCreateUser 


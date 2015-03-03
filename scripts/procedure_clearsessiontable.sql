USE MasterShopDb
GO

CREATE PROCEDURE ClearSessionTable
AS

DELETE
FROM Session 
WHERE LogoutDateTime is null

execute ClearSessionTable
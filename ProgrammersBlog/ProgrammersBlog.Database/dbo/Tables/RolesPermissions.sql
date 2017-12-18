CREATE TABLE [dbo].[RolesPermissions]
(
	[RoleId] INT NOT NULL , 
    [PermissionId] INT NOT NULL, 
    PRIMARY KEY ([RoleId], [PermissionId]), 
    CONSTRAINT [FK_RolesPermissions_ToRoles] FOREIGN KEY ([RoleID]) REFERENCES [Roles]([RoleId]), 
    CONSTRAINT [FK_RolesPermissions_ToPermissions] FOREIGN KEY ([PermissionId]) REFERENCES [permissions]([PermissionId]) 
)

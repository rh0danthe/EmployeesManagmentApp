UPDATE "Companies" SET "Name" = @Name WHERE "Id" = @id RETURNING *;
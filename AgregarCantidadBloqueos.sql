-- Agregar columna CantidadBloqueos a la tabla Usuario.
-- Ejecutar una sola vez.

ALTER TABLE Usuario
ADD CantidadBloqueos INT NOT NULL DEFAULT 0;

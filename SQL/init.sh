#!/bin/bash

/opt/mssql/bin/sqlservr &

echo "⏳ Waiting for SQL Server to be ready..."

SQLCMD="/opt/mssql-tools18/bin/sqlcmd"

until $SQLCMD -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -C -Q "SELECT 1" &> /dev/null
do
  sleep 2
done

echo "🚀 Running store.sql..."

$SQLCMD -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -C -i /store.sql

echo "✅ Database initialized"

wait
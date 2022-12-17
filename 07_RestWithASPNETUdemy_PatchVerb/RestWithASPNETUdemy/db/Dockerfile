FROM mcr.microsoft.com/mssql/server:2019-latest
EXPOSE 3306
COPY ./RestWithASPNETUdemy/db/migrations/ /home/database/
COPY ./RestWithASPNETUdemy/db/dataset/ /home/database/
COPY ./RestWithASPNETUdemy/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh
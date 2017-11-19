#!/bin/bash
set -e

if [ "$1" = 'apache2-reverse-proxy' ]; then
    source /etc/apache2/envvars
    exec service apache2 start 
	exec dotnet run apache.dll
fi

exec "$@"
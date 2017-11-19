FROM microsoft/aspnetcore-build

ENV DEBIAN_FRONTEND noninteractive

RUN apt-get update

RUN apt-get -y install ansible python-apt

COPY ansible/* /etc/ansible/

RUN ansible-playbook -i "localhost," -c local /etc/ansible/site.yml

RUN apt-get -y remove ansible python-apt;apt-get -y autoremove

RUN apt-get clean && rm -rf /var/lib/apt/lists/*

ARG source
WORKDIR /app

EXPOSE 5001
EXPOSE 80
EXPOSE 443

COPY ${source:-publish} .

COPY httpd.conf /usr/local/apache2/conf/httpd.conf
COPY httpd.conf /etc/apache2/sites-enabled/httpd.conf

COPY start.sh /usr/local/bin

ENTRYPOINT ["/bin/bash","start.sh"]


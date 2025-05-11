FROM wordpress:latest

# Tema ve eklentileri yükle
RUN apt-get update && apt-get install -y wget unzip \
    && wget https://downloads.wordpress.org/theme/twentytwentytwo.1.1.zip -O /tmp/theme.zip \
    && wget https://downloads.wordpress.org/plugin/jetpack.zip -O /tmp/jetpack.zip \
    && unzip /tmp/theme.zip -d /var/www/html/wp-content/themes/ \
    && unzip /tmp/jetpack.zip -d /var/www/html/wp-content/plugins/ \
    && rm /tmp/theme.zip /tmp/jetpack.zip

# WordPress dosyalarının izinlerini ayarla
RUN chown -R www-data:www-data /var/www/html

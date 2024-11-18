# *Java - GlobalSolution LessPollu*

### Sumário
- [Objetivo](#objetivo)
- [Tecnologias e Ferramentas](#tecnologias-e-ferramentas)
- [Proposta de Valor](#proposta-de-valor)
- [Modelo de Negócio](#modelo-de-negócio)
- [Impacto Socioambiental](#impacto-socioambiental)
- [Desafios e Soluções](#desafios-e-soluções)

## Objetivo
O projeto visa criar uma solução que monitore, em tempo real, a emissão de gases poluentes de indústrias, fornecendo dados sobre o impacto ambiental e apoiando a adoção de práticas mais sustentáveis. Além disso, busca-se que as indústrias tenham incentivos para adotar metas de emissão reduzida e para trabalhar em conformidade com regulamentações ambientais.
Facilitar a coleta, o monitoramento e a análise de dados relacionados a processos energéticos sustentáveis. A API ajudará empresas e stakeholders a compreender e otimizar o uso de fontes renováveis de energia.


## Tecnologias e Ferramentas
- **Sensores IoT:** Dispositivos IoT seriam instalados em fábricas para monitoramento de poluentes como dióxido de carbono (CO₂), óxidos de nitrogênio (NOx), monóxido de carbono (CO), entre outros.
- **Plataforma na Nuvem:** Um sistema que armazene dados em tempo real, acessível às autoridades reguladoras e às próprias indústrias. Ferramentas como AWS IoT, Google Cloud IoT, ou Azure IoT seriam boas opções.
- **Machine Learning e IA:** Algoritmos de machine learning podem prever padrões de emissão, detectar desvios e fornecer insights sobre formas de reduzir poluentes.
- **Blockchain:** Para garantir a integridade e a transparência dos dados. Blockchain pode ser usado para armazenar registros de emissões de maneira imutável, criando confiança no sistema.
Interface para Visualização de Dados: Dashboards que permitam a visualização das emissões, comparações históricas e indicadores de conformidade com regulamentações ambientais.

## Proposta de Valor
- **Para Indústrias:** Reduzir emissões pode ser economicamente vantajoso, pois além de evitar multas, as empresas poderiam ser elegíveis para incentivos governamentais e parcerias sustentáveis.
- **Para o Governo e Sociedade:** Ter um sistema que permita o monitoramento das emissões em tempo real aumenta a transparência, fortalece a fiscalização e permite uma resposta rápida para mitigar danos ambientais.
 
## Modelo de Negócio
- **Assinatura e Licenciamento:** Cobrar uma taxa para o uso da plataforma com base no tamanho da indústria e na quantidade de dados processados.
- **Consultoria Sustentável:** Oferecer serviços de consultoria para ajudar as empresas a atingir suas metas de redução de emissão.
- **Parcerias com Órgãos Reguladores:** A plataforma pode atuar em parceria com governos e organizações ambientais, que podem usar os dados para gerar relatórios e criar políticas mais efetivas.

## Impacto Socioambiental
- **Justiça Social:** A redução de emissões beneficia comunidades locais, especialmente aquelas em áreas próximas às indústrias, diminuindo problemas de saúde e promovendo qualidade de vida.
- **Sustentabilidade Econômica:** A adoção de tecnologias de monitoramento de emissão pode motivar as indústrias a se adaptarem a práticas que, a longo prazo, reduzem desperdícios e otimizam processos produtivos.
- **Preservação Ambiental:** A diminuição dos poluentes industriais ajuda na conservação de ecossistemas, evitando danos irreversíveis a plantas, animais e ao solo.

## Desafios e Soluções
- **Adesão das Indústrias:** Algumas indústrias podem relutar em adotar o sistema devido ao custo inicial. Para superar isso, o modelo de negócio pode incluir uma fase inicial gratuita ou com descontos em troca de parcerias.
- **Precisão dos Dados:** Emissões podem variar conforme o tipo de produção e a localização geográfica. Sensores calibrados e algoritmos avançados são essenciais para garantir precisão.
- **Privacidade e Segurança dos Dados:** O uso de blockchain e criptografia pode fortalecer a segurança dos dados e permitir que empresas confiem no sistema sem temer o vazamento de informações confidenciais.


## Diagrama de Classes

## Instrução para rodar a aplicação

Para configurar sua aplicação, acesse o arquivo `application.properties`. Neste arquivo, você encontrará propriedades que permitem personalizar o comportamento da sua aplicação.
Para conectar ao banco de dados, localize as propriedades username password. Nestas propriedades, insira respectivamente o nome de usuário e a senha para acessar o seu banco de dados. 

### Exemplo:
```
{
  datasource:
  url: jdbc:oracle:thin:@oracle.fiap.com.br:1521:orcl
  username: usuario
  password: senha
  driver-class-name: oracle.jdbc.OracleDriver
  jpa:
  hibernate:
  ddl-auto: create
  database-platform: org.hibernate.dialect.OracleDialect
}
```
Após realizar as alterações, salve o arquivo e execute a aplicação. A aplicação utilizará as novas credenciais para se conectar ao banco de dados.

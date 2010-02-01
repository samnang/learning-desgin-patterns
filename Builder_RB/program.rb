=begin
 Builder Pattern:
    - Separate the construction of a complex object from its representation so
      that the same construction process can create different representations.
    - Parse a complex representation, create one of several targets.
=end

#Abstract Builder
class SQLBuilder
  def initialize
    @generator = SQLGenerator.new
  end

  def get_sql_generator
    @generator
  end
end

#Concret Builder
class SQLServerBuilder < SQLBuilder
  def setup_connection
    @generator.connection = "SQL Server Connection"
  end

  def setup_sql_statement
     @generator.sql_statement = "TSQL"
  end
end

#Concret Builder
class OracleBuilder < SQLBuilder
  def setup_connection
    @generator.connection = "Oracle Connection"
  end

  def setup_sql_statement
     @generator.sql_statement = "PL/SQL"
  end
end

#Product
class SQLGenerator
  attr_accessor :connection, :sql_statement
end

#Director
class Client
  def initialize(builder)
    @builder = builder
  end

  def construct_sql_generator
    @builder.setup_connection
    @builder.setup_sql_statement
  end
end

#Program
sql_server_builder = SQLServerBuilder.new
client = Client.new(sql_server_builder)
client.construct_sql_generator
sql_generator = sql_server_builder.get_sql_generator
p sql_generator

oracle_builder = OracleBuilder.new
client = Client.new(oracle_builder)
client.construct_sql_generator
sql_generator = oracle_builder.get_sql_generator
p sql_generator
=begin
 Facade Pattern:
    - Provides an unified interface to a set of interfaces in a subsystem..
		- Defines a high-level interface that makes the sybsystem easier to use..
=end

#Subsystem classess
class HTTPRequest
	def request(url)
		puts "Request and return the reponse content"
	end
end

class ResponseParser	
	def parse(content)
		puts "Parse content into a ruby object and return to caller"
	end
end

#Facade: to simplify the interface for clients
class SimpleHTTPClient
	def get(url)
		response = HTTPRequest.new.request(url)
		
		ResponseParser.new.parse(response)
	end
end

#Running example
SimpleHTTPClient.new.get("http://yourdomain.com/resource.xml")
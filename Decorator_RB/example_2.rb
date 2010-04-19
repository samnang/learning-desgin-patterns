=begin
 Decorator Pattern:
    - Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.
    - Client-specified embellishment of a core object by recursively wrapping it.
    - Wrapping a gift, putting it in a box, and wrapping the box.
=end

#Concret Component
class Button
	def draw
		puts "Drawing button"
	end
end

#Running example
button = Button.new

#Decorator
class << button
	alias old_draw draw
	
	def draw
		old_draw
		puts "Drawing icon"
	end
	
	def icon_path=(path)
		puts "set icon path to #{path}"
	end
end

button.icon_path=("local path")
button.draw
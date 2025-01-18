#include <iostream>
#include <exception>

#include <HTTPRequest.hpp>



int main()
{
	try
	{
		http::Request request("http://discord.com/api/v10");
		const auto response = request.send();

		std::cout << std::string(response.body.begin(), response.body.end()) << std::endl;
	}
	catch (const std::exception& e)
	{
		std::cerr << "Error: " << e.what() << std::endl;
	}


	return 0;
}

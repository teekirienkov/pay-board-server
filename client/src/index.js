a = async () => {

	let response = await fetch('http://localhost:50711/api/test/5');
	
	if (response.ok) { 
		return response.json();
	} else {
		console.log(`Error ${response.status}`)
	}
}

// a()
// 	.then(response => console.log(response));


async function sendRequest (method, url, body) {
	const headersNull = {
		'Content-Type': 'text/html'
	}
	return await fetch(url, { 					// Вторым параметром в fetch передается конфигурация
		method: method, 						// Метод запроса (GET or POST)
		body: body, // Приводит отправляемые данные в JSON формат
		headers: headersNull
	})
}

const body1 = 'wdwdwdw';

sendRequest('PUT', 'http://localhost:50711/api/test/5', body1);
class Service {
  async getData(url) {
    const res = await fetch(url)
    if (res.ok) {
      return res.json()
    } else {
      return new Error(`Error: ${res.status}`)
    }
  }
}

export default Service;
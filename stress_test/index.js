import http from 'k6/http'
import { check, sleep } from 'k6'

export const options = {
    vus: 1000,
    duration: '3s'
}

export default function () {
  // const data = { username: 'username', password: 'password' }
  let res = http.get('http://localhost:5161/health')
  
  check(res, { 'success requests': (r) => r.status === 200 })
  //http.get('http://localhost:5161/health')

  sleep(0.3) 
}

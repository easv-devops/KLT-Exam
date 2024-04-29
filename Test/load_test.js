import http from 'k6/http';
import {sleep } from 'k6';

export const options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '5m', target: 100 }, // Ramp up to 100 users over 5 minutes
        { duration: '10m', target: 100 }, // Stay at 100 users for 10 minutes
        { duration: '5m', target: 0 }, // Ramp down to 0 users over 5 minutes
    ],
    
    thresholds: {
        // You can define thresholds for your test here
        http_req_duration: ['p(95)<500'], // 95% of requests should be below 500ms
    },
};


export default () => {
    http.get('http://144.91.64.53:5100/currency/get?testing=true');
    sleep(1);
}



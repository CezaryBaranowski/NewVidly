interface AuthConfig {
    clientID: string;
    domain: string;
    callbackURL: string;
    rolesClaim: string;
  }

  export const AUTH_CONFIG: AuthConfig = {
    clientID: 'BMdXIV7Ayew0zcU1WZtP1FCNaVsFvm0Z',
    domain: 'newvidly.eu.auth0.com',
    callbackURL: 'https://localhost:5001',
    rolesClaim: 'https://newvidly.eu.com/roles'
  };

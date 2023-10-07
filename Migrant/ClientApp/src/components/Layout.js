import React from 'react';
import NavMenu from './NavMenu';

const Layout = ({ aidMode = false, children }) => {
  return (
    <div>
      <NavMenu aidMode={aidMode} />
      <div className="main-container">
        {children}
      </div>
    </div>
  );
}

export default Layout;

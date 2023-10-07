import React, { useState } from 'react';
import { Link } from "react-router-dom";
import Emblem from "../../assets/images/state_emblem.svg";
import EmblemBlue from "../../assets/images/state_emblem_blue.svg"
import styles from './NavMenu.module.scss';

const registrationLinks = [
  {to: "/", title: "На початок"},
  {to: "/person/create", title: "Зареєструвати ВПО"},
  {to: "#", title: "Реєстр ВПО"},
  {to: "#", title: "Пошук"},
  {to: "#", title: "Звітність"},
];

const aidLinks = [
  {to: "/aid", title: "На початок"},
  {to: "#", title: "Перевірка отримання"},
  {to: "#", title: "Видача допомоги"},
  {to: "#", title: "Журнал роботи"},
  {to: "#", title: "Звітність"},
]

const NavMenu = ({ aidMode = false }) => {
  const links = aidMode ? aidLinks : registrationLinks;
  const [openMenu, setOpenMenu] = useState(false);

  const toggleMenu = () => {
    setOpenMenu(!openMenu)
  }

  return (
    <header className={`${styles.header} ${aidMode ? styles.aidMode : ''}`}>
      <Link to="/" className={styles.logo}>
        <img src={aidMode ? EmblemBlue : Emblem} alt="emblem" />
        <span>{aidMode ? "Видача гуманітарної допомоги ВПО" : "Облік та реєстрація ВПО"}</span>
      </Link>
      <ul className={`desktop-only ${styles.navigation}`}>
        {links.map((link, i) => (
          <li key={`desktop-nav-item-${i}`}>
            <Link to={link.to} className={styles.navItem}>
              {link.title}
            </Link>
          </li>
        ))}
      </ul>
      <div className={`desktop-only ${styles.rightBar}`}>
        <Link to={aidMode ? "/" : "/aid"}>
          <div className={styles.modeChanger}>
            <p>Перейти до</p>
            {aidMode ? "Реєстрації" : "Видачі допомоги"}
          </div>
        </Link>
        <div>Користувач: @@@</div>
        <div><Link to="#">Вийти</Link></div>
      </div>
      <button className={styles.menuButton} onClick={toggleMenu}>
        Меню
      </button>
      <div className={`${styles.mobileMenu} ${openMenu ? styles.open : ''}`}>
        <button className={styles.closeMenuButton} onClick={toggleMenu} />
        {links.map((link, i) => (
          <Link to={link.to} key={`mobile-nav-item-${i}`}>
            {link.title}
          </Link>
        ))}
        <div>
          {aidMode ? (
            <Link to="/">
              <p>Перейти до</p>
              Реєстрації
            </Link>
          ) : (
            <Link to="/aid">
              <p>Перейти до</p>
              Видачі допомоги
            </Link>
          )}
        </div>
        <p>Користувач: @@@</p>
        <Link to="#">Вийти</Link>
      </div>
      {/* <NavItem>
        <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
      </NavItem> */}
    </header>
  );
}

export default NavMenu;

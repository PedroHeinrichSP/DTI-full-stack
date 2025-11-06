import { NavLink, useLocation } from "react-router-dom";
import { useEffect, useState } from "react";

function Navbar() {
  const location = useLocation();
  const [indicatorStyle, setIndicatorStyle] = useState({
    left: "0%",
    backgroundColor: "#f97316",
  });

  useEffect(() => {
    if (location.pathname.includes("accepted")) {
      setIndicatorStyle({ left: "50%", backgroundColor: "#22c55e" });
    } else {
      setIndicatorStyle({ left: "0%", backgroundColor: "#f97316" });
    }
  }, [location.pathname]);

  return (
    <nav className="relative bg-white dark:bg-gray-900 border-b border-gray-200 dark:border-gray-700">
      <div className="max-w-6xl mx-auto flex relative">
        <NavLink
          to="/invited"
          end
          className={({ isActive }) =>
            `flex-1 text-center py-3 text-sm font-medium transition-colors ${
              isActive
                ? "text-gray-900 dark:text-white font-semibold"
                : "text-gray-500 dark:text-gray-400 hover:text-gray-800 dark:hover:text-gray-200"
            }`
          }
        >
          Invited
        </NavLink>
        <NavLink
          to="/accepted"
          className={({ isActive }) =>
            `flex-1 text-center py-3 text-sm font-medium transition-colors ${
              isActive
                ? "text-gray-900 dark:text-white font-semibold"
                : "text-gray-500 dark:text-gray-400 hover:text-gray-800 dark:hover:text-gray-200"
            }`
          }
        >
          Accepted
        </NavLink>
        <span
          className="absolute bottom-0 h-[3px] w-1/2 rounded-full transition-all duration-300 ease-in-out"
          style={{
            left: indicatorStyle.left,
            backgroundColor: indicatorStyle.backgroundColor,
          }}
        />
      </div>
    </nav>
  );
}
export default Navbar;

let db = null;

export async function initDb() {
    if (!db) {
        const sqlite3 = await sqlite3InitModule();
        db = new sqlite3.oo1.DB();
        console.log("Database initialized");
    }
}

export function executeSql(sql) {
    if (!db) throw new Error("Database is not initialized.");
    try {
        db.exec(sql);
        console.log("SQL executed: " + sql);
    } catch (e) {
        console.error("SQL execution error:", e);
    }
}

export function querySql(sql) {
    if (!db) throw new Error("Database is not initialized.");
    const result = [];
    db.exec({
        sql,
        rowMode: 'object',
        callback: (row) => result.push(row),
    });
    return result;
}
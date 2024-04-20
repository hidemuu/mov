import { IsWriteLog } from "utils/developConstants";

export function writeLogs(messages: any[]) {
  if (IsWriteLog) {
    for (const message of messages) {
      writeLog(message);
    }
  }
}

export function writeLog(message: any) {
  if (IsWriteLog) {
    console.log(message);
  }
}

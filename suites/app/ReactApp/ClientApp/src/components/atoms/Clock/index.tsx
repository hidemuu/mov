import React, { useState, useEffect } from 'react'
import { LocaleType } from '../../../domains/locales/types/LocaleType'
import { Locale } from '../../../domains/locales/models/Locale'

const UPDATE_CYCLE = 1000

const KEY_LOCALE = 'KEY_LOCALE'

export const Clock = () => {
  const [timestamp, setTimestamp] = useState(new Date())
  const [locale, setLocale] = useState(new Locale(LocaleType.US))

  useEffect(() => {
    const timer = setInterval(() => {
      setTimestamp(new Date())
    }, UPDATE_CYCLE)

    return () => {
      clearInterval(timer)
    }
  }, [])

  useEffect(() => {
    const savedLocale = localStorage.getItem(KEY_LOCALE)
    if (savedLocale !== null) {
      setLocale(new Locale(savedLocale))
    }
  }, [])

  useEffect(() => {
    localStorage.setItem(KEY_LOCALE, locale.toLocaleString())
  }, [locale])

  return (
    <div>
      <p>
        <span id="current-time-label">現在時刻</span>
        <span>:{timestamp.toLocaleString(locale.toLocaleString())}</span>
        <select
          value={locale.toLocaleString()}
          onChange={(e) => setLocale(new Locale(e.target.value))}
        >
          <option value="en-US">en-US</option>
          <option value="ja-JP">ja-JP</option>
        </select>
      </p>
    </div>
  )
}
